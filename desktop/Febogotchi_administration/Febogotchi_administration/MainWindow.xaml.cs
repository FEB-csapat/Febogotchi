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

namespace Febogotchi_administration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewEntity_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab EntityTab = new AdministrationTab(1);
            EntityTab.Show();
        }

        private void UserNewPassword_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab EntityTab = new AdministrationTab(2);
            EntityTab.Show();
        }

        private void ListUsers_Click(object sender, RoutedEventArgs e)
        {
            ApiReader apireader = new ApiReader("http://localhost:8881/");
            MessageBox.Show($"{apireader.GetUsers("api/users/1")}");
        }
    }
}
