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

namespace PaymentsProject.ProjectControls
{
    /// <summary>
    /// Логика взаимодействия для CounterUserControl.xaml
    /// </summary>
    public partial class CounterUserControl : UserControl
    {
        public CounterUserControl()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void CountUserControlBtnUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountUserControlBtnDown_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
