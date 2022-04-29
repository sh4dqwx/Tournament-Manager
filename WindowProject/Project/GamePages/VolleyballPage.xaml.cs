using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project.GamePages
{
    public partial class VolleyballPage : Page
    {
        private MenuPage _menu;
        public string name = "Tak";
        public VolleyballPage(MenuPage menu)
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
