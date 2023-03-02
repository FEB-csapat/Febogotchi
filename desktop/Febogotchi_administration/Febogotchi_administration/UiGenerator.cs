using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Numerics;

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
        private Button passwordchange;
        Grid AdministrationGrid;
        bool containsnumeric = false;
        bool containsupper = false;
        private Button createuser;
        public UiGenerator(Grid ToRequest)
        {
            AdministrationGrid = ToRequest;
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
        public void UserDataChange()
        {
            ClearGrid();
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
            UserName = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 175,
                Margin = new Thickness(0, 15, 0, 0)
            };
            AdministrationGrid.Children.Add(UserName);
            Grid.SetColumn(UserName, 1);
            Grid.SetRow(UserName, 1);
            label = new Label
            {
                Content = "Aktív felhasználó:",
                HorizontalAlignment = HorizontalAlignment.Left
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);
            _username = new Label
            {
                Content = UserName.Text,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(_username);
            Grid.SetColumn(_username, 0);
            Grid.SetRow(_username, 0);
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
            //check if user exists
            //if exists -> show ShowUserModifiableData
            //if not-> show UserDataChange
            if (UserName.Text!="")
            {
                _username.Content = UserName.Text;
                ShowUserModifiableData();
            }
            else
            {
                MessageBox.Show($"Nem lehet üresen hagyni!", "Hibás felhasználónév!");
            }
           
        }
        private void ShowUserModifiableData()
        {
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
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Biztosan törölni szertné a felhasználót? ( {_username.Content} )", "Felhasználó törlés megerősítés", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MessageBox.Show($"Sikeresen törölte ( {_username.Content} ) nevű felhasználót.", "Sikeres felhasználó törlés");
            }
        }
        private void passwordchange_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text == repassword.Text)
            {
                if (password.Text.Length<8)
                {
                    MessageBox.Show($"Túl rövid jelszó!", "Hibás jelszó!");
                    return;
                }
                foreach (var item in password.Text)
                {
                    if (Char.IsDigit(item))
                    {
                        containsnumeric = true;
                    }
                    if (Char.IsUpper(item))
                    {
                        containsupper = true;
                    }
                }
                if (!containsnumeric)
                {
                    MessageBox.Show($"Legalább egy számmal rendelkeznie kell a jelszónak!", "Hibás jelszó!");
                    return;
                }
                if (!containsupper)
                {
                    MessageBox.Show($"Legalább egy nagybetűvel rendelkeznie kell a jelszónak!", "Hibás jelszó!");
                    return;
                }
                MessageBox.Show($"Sikeresen megváltoztatta a felhasználó jelszavát", "Sikeres jelszó változtatás");
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
            //users.Add(apireader.GetUser("api/users/1"));
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
            List <Users> users = getAllUser();
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
            ApiSender apiSender = new ApiSender();
            apiSender.CreateUser(UserName.Text, password.Text, "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiYjE5Yzk0NTAxYWExMDdlNDk1MzIxNGEzNDY3MWQ2ODE1NzI4NTJkNTQ1YmE1MWQ4ZmJmZjk3MDEyZjQ3ZDc5YzBjMGNjNjJlNzIxNTg5NjEiLCJpYXQiOjE2Nzc3NTk2MDkuODg2MDk3LCJuYmYiOjE2Nzc3NTk2MDkuODg2MSwiZXhwIjoxNzA5MzgyMDA5LjgyNTcxOSwic3ViIjoiMiIsInNjb3BlcyI6W119.E5eRxRcSvW3UKvQTkHq4aL0UzFRNUGny4tUGv-4nSdSeU8dTUS1IMCNj8j4hXQ6LWFYYNeHiyY4utP4zvjkCyC-K5jOPZhOlpaka6xsX5IrRUmerRUGlYtFMrW0tFdjGbr1ziN-VaPuLNLNZf0DttLw-I5oj5fZ-guY4eLFAjB7WTdIkRIUSRJIneLHgkz9Ky781iOxgU57nEZymXoO6SMIgbegmwHzUGHIajInKY9kgg6KYojNmHaEeV9XlKL1WQ0DEpWiNWhWOOO8Ki0PTxq8EkMf5tfMhy-OWN5jIeyFdn6xPtfITgKSfyFJLFU1w9YTVQjCRQxURFwLSOIinDN5BHk43zLSRZJa3tGdRLeJxDAkSDTlCGAo4oXRP4ud2NCzLxyIWlq1g0dytXw9vY7gYgazzLS8cm4KJHuvTCIxAkoOWDlIhPROhzg1xllQGre5dTbX3CocGbparuLIk5a1ScrHp7SpOc68tce3JaKSkYDHXlQzlE2-x1RLhjoNMORq3APh2qOKjMzXM6YHid-TyYZDf8x09-HGIEXIJ9y5cWuqeBpJdTxokH81Tz4N0GjSkpD0AV3Yd9JyBE18V6rsncdfIV-4x3E8G4ix-Nzz45mi7QZgLLpevfs2azD4Wp5BNL-dbglLHuJdi5G8x1COEa3lj7pSK80ZifOlcTWQ");
        }
    }
}
