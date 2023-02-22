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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Core db = new Core();
        public MainPage()
        {
            InitializeComponent();
            CategoryCombo.ItemsSource = db.context.Category.ToList();
            CategoryCombo.DisplayMemberPath = "name_category";
            CategoryCombo.SelectedValuePath = "id_category";
            CategoryCombo.SelectedIndex = 1;
            MainGrid.ItemsSource = db.context.Payment.Where(p => p.user_id == App.CurrentUser.id_user).ToList();
            DisplayListPayment();
        }

        private void DisplayListPayment()
        {
            if (CategoryCombo.SelectedIndex != 0)
            {
                int categoryChange = Convert.ToInt32(CategoryCombo.SelectedValue);
                MainGrid.ItemsSource = db.context.Payment.Where(x => x.category_id == categoryChange).ToList();
            }
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddPaymentsPage());
        }

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayListPayment();
        }

        private void DeleteButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var item = MainGrid.SelectedItem as Payment;
            if (item == null)
            {
                MessageBox.Show("Вы не выбрали ни одной строки");
                return;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.context.Payment.Remove(item);
                    db.context.SaveChanges();
                    MessageBox.Show("Информация удалена");
                    MainGrid.ItemsSource = db.context.Payment.ToList();

                }
            }
        }
    }
}
