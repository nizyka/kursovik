using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace курс
{
    /// <summary>
    /// Логика взаимодействия для AddZ.xaml
    /// </summary>
    public partial class AddZ : Window
    {
        public AddZ(Zakazi zakazi)
        {
            InitializeComponent();
            DataContext = zakazi;

            staCmB.ItemsSource = Date_base.GetContext().Statys.ToList();

        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (volumTB.SelectedText == null)
                error.AppendLine("Вы не заполнили Дату принятия заказа");
            if (staCmB.SelectedItem == null)
                error.AppendLine("Вы не выбрали Статус заказа");
            if (sumTB.SelectedText == null)
                error.AppendLine("Вы не ввели Сумму заказа");
           

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
           Zakazi zakazi = new Zakazi()
            {
                
                Volume = double.Parse(volumTB.Text),
               Sum = double.Parse(sumTB.Text),
               Statys = staCmB.SelectedItem as Statys
            };
            //DBClass.GetContext().Products.Add(products);
            //ProductsIngredient productsIngredient = new ProductsIngredient()
            //{
            //    Products = products,
            //    Ingredient = ingredCmB.SelectedItem as Ingredient
            //};
            //DBClass.GetContext().ProductsIngredient.Add(productsIngredient);


            Date_base.GetContext().SaveChanges();
            Date_base.ApplyDataBaseChange();
            MessageBox.Show("Заказ усешно создан");
            Close();
        }
    }
}
