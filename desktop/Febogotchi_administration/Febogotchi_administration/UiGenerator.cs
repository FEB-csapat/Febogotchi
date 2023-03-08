using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Febogotchi_administration
{
    public class UiGenerator
    {
        private Label label;
        private Label _username;
        private TextBox UserName;
        private Button select;
        private TextBox password;
        private TextBox repassword;
        private Button userdelete;
        private ComboBox UsersCB;
        private Button passwordchange;
        Grid AdministrationGrid;
        private List<Users> users;
        int toupdateindex;
        private List<string> usernames = new List<string>();
        bool containsnumeric = false;
        bool containsupper = false;
        private Button createuser;
        private string username;
        ApiSender apiSender = new ApiSender();
        public string Token { get; set; }
        public UiGenerator(Grid ToRequest,string token)
        {
            AdministrationGrid = ToRequest;
            Token = token;
        }
        private void ClearGrid()
        {
            AdministrationGrid.RowDefinitions.Clear();
            AdministrationGrid.ColumnDefinitions.Clear();
            AdministrationGrid.Children.Clear();
        }
        public void NewEntityGenerate()
        {
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            label = new Label
            {
                Content = "Új lény neve:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);
            TextBox EntityName = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 350
            };
            AdministrationGrid.Children.Add(EntityName);
            Grid.SetColumn(EntityName, 1);
            Grid.SetRow(EntityName, 0);
        }
        public void Activeuser(string tb)
        {
            _username = new Label
            {
                Content = tb,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(_username);
            Grid.SetColumn(_username, 0);
            Grid.SetRow(_username, 0);
        }
        private void GetAllUserNames()
        {
            usernames.Clear();
            foreach (var item in getAllUser())
            {
                usernames.Add(item.name);
            }
        }
        public void UserDataChange()
        {
            GetAllUserNames();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(45, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            label = new Label
            {
                Content = "Felhasználó neve:",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0,15,0,0)
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 1);

            UsersCB = new ComboBox 
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 175,
                Margin = new Thickness(0, 15, 0, 0)
            };
            UsersCB.ItemsSource = usernames;
            Activeuser(username);
            AdministrationGrid.Children.Add(UsersCB);
            Grid.SetColumn(UsersCB, 1);
            Grid.SetRow(UsersCB, 1);

            label = new Label
            {
                Content = "Aktív felhasználó:",
                HorizontalAlignment = HorizontalAlignment.Left
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);

            select = new Button
            {
                Content = "Kiválasztás",
                Margin = new Thickness(10, 10, 0, 10),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 425
            };
            AdministrationGrid.Children.Add(select);
            Grid.SetColumnSpan(select, 2);
            Grid.SetRow(select, 2);

            select.Click += select_Click;
        }
        
        private void select_Click(object sender, RoutedEventArgs e)
        {
            if (UsersCB.SelectedItem.ToString() != "")
            {
                users = getAllUser();
                _username.Content = UsersCB.SelectedItem.ToString();
                username = UsersCB.SelectedItem.ToString();
                toupdateindex = users.FindIndex(x => x.name == UsersCB.SelectedItem.ToString())+1;
                ShowUserModifiableData();
            }
            else
            {
                MessageBox.Show($"Nem lehet üresen hagyni!", "Hibás felhasználónév!");
            }
        }
        private void ShowUserModifiableData()
        {
            ClearGrid();
            UserDataChange();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(45, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            label = new Label
            {
                Content = "Új jelszó:",
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 3);
            password = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 175,
                Height = 25
            };
            AdministrationGrid.Children.Add(password);
            Grid.SetColumn(password, 1);
            Grid.SetRow(password, 3);

            label = new Label
            {
                Content = "Új jelszó megerősítése:",
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 4);
            repassword = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 175,
                Height = 25
            };
            AdministrationGrid.Children.Add(repassword);
            Grid.SetColumn(repassword, 1);
            Grid.SetRow(repassword, 4);
            passwordchange = new Button
            {
                Content = "Új jelszó beállítása",
                Margin = new Thickness(10, 10, 0, 10),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 425
            };
            AdministrationGrid.Children.Add(passwordchange);
            Grid.SetColumnSpan(passwordchange, 2);
            Grid.SetRow(passwordchange, 5);
            passwordchange.Click += passwordchange_Click;
            label = new Label
            {
                Content = "Felhasználó törlése:",
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 6);
            userdelete = new Button
            {
                Content = "Törlés",
                Width = 175,
                Height = 25
            };
            AdministrationGrid.Children.Add(userdelete);
            Grid.SetColumn(userdelete, 1);
            Grid.SetRow(userdelete, 6);
            userdelete.Click += userdelete_Click;
        }
        private void userdelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Biztosan törölni szertné a felhasználót? ( {_username.Content} )", "Felhasználó törlés megerősítés", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                apiSender.DeleteUser(toupdateindex, Token);
            }
        }
        private void passwordchange_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text == repassword.Text)
            {
                //TODO: Move this validation to backend
                //if (password.Text.Length<8)
                //{
                //    MessageBox.Show($"Túl rövid jelszó!", "Hibás jelszó!");
                //    return;
                //}
                //foreach (var item in password.Text)
                //{
                //    if (Char.IsDigit(item))
                //    {
                //        containsnumeric = true;
                //    }
                //    if (Char.IsUpper(item))
                //    {
                //        containsupper = true;
                //    }
                //}
                //if (!containsnumeric)
                //{
                //    MessageBox.Show($"Legalább egy számmal rendelkeznie kell a jelszónak!", "Hibás jelszó!");
                //    return;
                //}
                //if (!containsupper)
                //{
                //    MessageBox.Show($"Legalább egy nagybetűvel rendelkeznie kell a jelszónak!", "Hibás jelszó!");
                //    return;
                //}
                apiSender = new ApiSender();
                apiSender.UpdateUser(toupdateindex, UsersCB.SelectedItem.ToString(), password.Text,Token);
            }
            else
            {
                MessageBox.Show($"A jelszavak nem egyeznek!", "Hibás jelszó!");
            }
        }
        private List<Users> getAllUser()
        {
            List<Users> users = new List<Users>();
            ApiReader apireader = new ApiReader("http://localhost:8881/");
            foreach (var item in apireader.GetUsers("api/users"))
            {
                users.Add(item);
            }
            return users;
        }
        public void ShowListedUsers()
        {
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            label = new Label
            {
                Content = "Felhasználó azonosítója:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);
            label = new Label
            {
                Content = "Felhasználó neve:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 0);
            label = new Label
            {
                Content = "Felhasználó szerepköre:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 2);
            Grid.SetRow(label, 0);
            users = getAllUser();
            int rows = 1;
            int cols;
            foreach (var item in users)
            {
                AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
                cols = 0;
                label = new Label
                {
                    Content = item.id,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                AdministrationGrid.Children.Add(label);
                Grid.SetColumn(label, cols);
                Grid.SetRow(label, rows);
                cols++;
                label = new Label
                {
                    Content = item.name,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                AdministrationGrid.Children.Add(label);
                Grid.SetColumn(label, cols);
                Grid.SetRow(label, rows);
                cols++;
                label = new Label
                {
                    Content = item.roles[0],
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                AdministrationGrid.Children.Add(label);
                Grid.SetColumn(label, cols);
                Grid.SetRow(label, rows);
                cols++;
                rows++;
            }
        }
        public void UserCreation()
        {
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            label = new Label
            {
                Content = "Adja meg az új felhasználó felhasználónevét és jelszavát:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumnSpan(label, 2);
            Grid.SetRow(label, 0);
            label = new Label
            {
                Content = "Felhasználónév:",
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 1);
            label = new Label
            {
                Content = "Jelszó:",
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 2);
            label = new Label
            {
                Content = "Jelszó újra:",
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 3);
            UserName = new TextBox
            {
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            AdministrationGrid.Children.Add(UserName);
            Grid.SetColumn(UserName, 1);
            Grid.SetRow(UserName, 1);
            password = new TextBox
            {
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            AdministrationGrid.Children.Add(password);
            Grid.SetColumn(password, 1);
            Grid.SetRow(password, 2);
            repassword = new TextBox
            {
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            AdministrationGrid.Children.Add(repassword);
            Grid.SetColumn(repassword, 1);
            Grid.SetRow(repassword, 3);
            createuser = new Button
            {
                Content = "Regisztráció",
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 300
            };
            AdministrationGrid.Children.Add(createuser);
            Grid.SetColumnSpan(createuser, 2);
            Grid.SetRow(createuser, 4);
            createuser.Click += createuser_Click;
        }
        private void createuser_Click(object sender, RoutedEventArgs e)
        {
            apiSender = new ApiSender();
            apiSender.CreateUser(UserName.Text, password.Text, Token);
        }
    }
}
