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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace курс
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
       
        private Dispetsher dispetsher;
        ICollection<Zakazi> zakazi;
        Zakazi zakAll;
        
        List<Zakazi> filterList = new List<Zakazi>();
        
        public Menu(Dispetsher dispetsher)
        {
            InitializeComponent();
            zakAll = new Zakazi();
            this.dispetsher = dispetsher;
            listboxView.ItemsSource = Date_base.GetContext().Zakazi.ToList();

            List<Zakazi> filterZakazi = new List<Zakazi>();
            filterZakazi.Add(zakAll);
            filterZakazi.AddRange(Date_base.GetContext().Zakazi.ToList());
            filterCmB.ItemsSource = filterZakazi;
            MyDB();
        }

        public void MyDB()
        {
            
            zakazi = Date_base.GetContext().Zakazi.ToList();
            //поиск
            if (!String.IsNullOrEmpty(searchTxB.Text.Trim()))
                zakazi = zakazi.Where(p => p.Data_prin_zak.Contains(searchTxB.Text) ||
                (String.IsNullOrEmpty(p.Volume) &&
                p.Volume.Contains(searchTxB.Text))).ToList();
            if (filterList.Count > 0)
                zakazi = zakazi.Where(p => filterList.Contains(p.Zayavka)).ToList();
        }


        //фильтрация
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (((Zakazi)checkBox.DataContext) != zakAll)
                filterList.Add((Zakazi)checkBox.DataContext);
            else
            {
                filterList.Clear();
                filterCmB.ItemsSource = null;
                List<Zakazi> filterCategory = new List<Zakazi>();
                filterCategory.Add(zakAll);
                filterCategory.AddRange(Date_base.GetContext().Zakazi.ToList());
                filterCmB.ItemsSource = filterCategory;
            }
        }


        private void searchTxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyDB();
        }


        private void filterCmB_DropDownClosed(object sender, EventArgs e)
        {
            MyDB();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            filterList.Remove((Zakazi)checkBox.DataContext);
        }



        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Zakazi zakazi = (sender as StackPanel).DataContext as Zakazi;
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            AddZ addZ = new AddZ((Zakazi)but.Tag);
            addZ.Owner = this;
            addZ.Show();
        }

        //private void edProd_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = sender as Button;
        //    Edd ed = new Edd((Zakazi)button.Tag);
        //    ed.Owner = this;
        //    ed.Show();
        //}
    }
}
