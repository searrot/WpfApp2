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

namespace WpfApp2
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
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();
            string passwordFirst = passBox_1.Password.Trim();
            string passwordSecond = passBox_2.Password.Trim();

            if (login.Length > 20 || login.Length <= 1)
            {
                MessageBox.Show("Длина логина не может быть меньше 1 и больше 20");
            }
            else if (passwordFirst.Length < 8)
            {
                MessageBox.Show( "Длина пароля не может быть меньше 8");
            }
            else if (passwordSecond != passwordFirst)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                MessageBox.Show($"Успешно!");
                User user = new User(login, passwordFirst);
                DbConnector.AddUser(user);
                SignInWindow signInWindow = new SignInWindow();
                signInWindow.Show();
                this.Hide();
            }

        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Hide();
        }

    }
}
