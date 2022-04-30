using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
