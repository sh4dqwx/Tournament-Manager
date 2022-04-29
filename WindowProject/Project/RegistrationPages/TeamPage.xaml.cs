using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project.RegistrationPages
{
    public partial class TeamPage : Page
    {
        private MenuPage _menu;
        public TeamPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }
    }
}
