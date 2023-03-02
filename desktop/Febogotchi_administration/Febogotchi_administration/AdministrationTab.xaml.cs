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
            UiGenerator UiTab = new UiGenerator(AdministrationGrid);
            switch (index)
            {
                case 1:
                    this.Title = "Új lény hozzáadása";
                    UiTab.NewEntityGenerate();
                    break;
                case 2:
                    this.Title = "Felhasználó adatainak módosítása";
                    UiTab.UserDataChange();
                    break;
                case 3:
                    this.Title = "Felhasználók listája";
                    UiTab.ShowListedUsers();
                    break;
                case 4:
                    this.Title = "Felhasználó létrehozása";
                    UiTab.UserCreation();
                    break;
            }
        }
        
        
    }
}
