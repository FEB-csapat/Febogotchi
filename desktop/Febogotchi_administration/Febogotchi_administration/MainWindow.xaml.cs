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
        public string token { get; set; }
        public MainWindow(string token)
        {
            InitializeComponent();
            this.token = token;
        }

        private void NewEntity_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab EntityTab = new AdministrationTab(1,token);
            EntityTab.Show();
        }

        private void UserNewPassword_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab ModifyUser = new AdministrationTab(2, token);
            ModifyUser.Show();
        }

        private void ListUsers_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab ListUsers = new AdministrationTab(3, token);
            ListUsers.Show();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            AdministrationTab CreateUser = new AdministrationTab(4, token);
            CreateUser.Show();
        }
    }
}
