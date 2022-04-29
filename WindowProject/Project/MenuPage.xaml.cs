using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private VolleyballPage volleyball;
        private TugOfWarPage tugOfWar;
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            volleyball = new VolleyballPage(this);
            tugOfWar = new TugOfWarPage(this);
            mainWindow = window;
        }
        private void Volleyball_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(volleyball);
        }

        private void TugOfWar_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(tugOfWar);
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy zapisać stan programu?", "Wyjście", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

            }
            mainWindow.Close();
        }
    }
}
