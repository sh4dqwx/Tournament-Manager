using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project.GamePages
{
    public partial class TugOfWarPage : Page
    {
        private MenuPage _menu;
        public TugOfWarPage(MenuPage menu)
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
