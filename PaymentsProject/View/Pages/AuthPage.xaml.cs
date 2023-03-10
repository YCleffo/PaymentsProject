using PaymentsProject.Model;
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

namespace PaymentsProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
            List<Users> users = db.context.Users.ToList();
            List<string> logins = new List<string>() { };
            foreach (Users item in users)
            {
                logins.Add(item.login);
            }
            UserComboBox.ItemsSource = logins;
            UserComboBox.SelectedIndex = 0;
        }
        //Проверка корректности пароля
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
           Users activeUser = db.context.Users.FirstOrDefault(x => x.login == UserComboBox.SelectedValue.ToString() && x.password == UserPasswordBox.Password);
            if (activeUser != null)
            {
                App.CurrentUser = activeUser;
                this.NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Введен не верный логин или пароль");
            }
            //Закрытие окна приложения

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.ActiveUser = UserComboBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
