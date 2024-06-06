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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();
            string passwordFirst = passBox_1.Password.Trim();
            User user = new User(login, passwordFirst);

            if (DbConnector.Check(user))
            {
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("Данные не верны");
            }

            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            this.Hide();
        }

        private void Button_Window_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
