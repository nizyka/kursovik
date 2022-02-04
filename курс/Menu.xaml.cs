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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Dispetsher dispetsher;
        ICollection<Zakazi> zakazi;
        public Menu(Dispetsher dispetsher)
        {
            InitializeComponent();
            this.dispetsher = dispetsher;
            MyDB();

        }

        public void MyDB()
        {
            zakazi = Date_base.GetContext().Zakazi.ToList();
        }

        //private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ClickCount == 2)
        //    {
        //        Zakazi zakazi = (sender as StackPanel).DataContext as Zakazi;
        //    }
        //}
    }
}
