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

namespace Project.RegistrationPages
{
    /// <summary>
    /// Logika interakcji dla klasy LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Page
    {
        private MenuPage _menu;
        public LoadPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        private void Load_Button(object sender, RoutedEventArgs e)
        {

        }
        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }
    }
}
