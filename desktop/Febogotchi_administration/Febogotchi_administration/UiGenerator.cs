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
        private void ShowListedUsers()
        {
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        }
    }
}
