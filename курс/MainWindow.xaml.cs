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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_auth_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(loginTextBox.Text))
            {
                if (!String.IsNullOrEmpty(password.Password))
                {
                    IQueryable<Dispetsher> dispetsher_list = Date_base.GetContext().Dispetsher.Where(p => p.Surname == loginTextBox.Text && p.Passvord == password.Password);
                    if (dispetsher_list.Count() == 1)
                    {
                      //  MessageBox.Show("Добро пожаловать, " + dispetsher_list.First().Name);
                        Menu menu = new Menu(dispetsher_list.First());
                        menu.Owner = this;
                        menu.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Неверный пароль или логин!");
                }
            }
        }
    }
}
