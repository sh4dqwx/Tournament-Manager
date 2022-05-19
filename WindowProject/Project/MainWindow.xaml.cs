using System;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Project.Interface;

namespace Project
{
    public partial class MainWindow : Window
    {
        private MenuPage _menuPage;
        public MainWindow()
        {
            InitializeComponent();
            _menuPage = new MenuPage(this);
            PageFrame.Navigate(_menuPage);
        }

        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            //Logika do zamykania okna
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
