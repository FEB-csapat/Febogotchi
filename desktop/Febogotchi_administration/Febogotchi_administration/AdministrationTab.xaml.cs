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

namespace Febogotchi_administration
{
    /// <summary>
    /// Interaction logic for AdministrationTab.xaml
    /// </summary>
    public partial class AdministrationTab : Window
    {
        public AdministrationTab(int index)
        {
            InitializeComponent();
            DataContext = this.DataContext;
            switch (index)
            {
                case 1:
                    NewEntityGenerate();
                    break;
                case 2:
                    UserDataChange();
                    break;
            }
        }
        private void ClearGrid()
        {
            AdministrationGrid.RowDefinitions.Clear();
            AdministrationGrid.ColumnDefinitions.Clear();
            AdministrationGrid.Children.Clear();
        }
        protected void NewEntityGenerate()
        {
            this.Title = "Új lény hozzáadása";
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Label label = new Label
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
        private void UserDataChange()
        {
            this.Title = "Felhasználó adatainak módosítása";
            ClearGrid();
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25, GridUnitType.Pixel) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            AdministrationGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Label label = new Label
            {
                Content = "Felhasználó neve:",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 1);
            TextBox UserName = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 175,
                Text = "qwertzuiodfhhdfsdfghj"
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
            label = new Label
            {
                Content = UserName.Text,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            AdministrationGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);
        }
        private void UserDelete()
        {
            this.Title = "Felhasználó törlése";
            ClearGrid();
        }
    }
}
