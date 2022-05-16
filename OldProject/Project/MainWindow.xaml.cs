using System;
using System.Windows;

namespace Project
{
    public partial class MainWindow : Window
    {
        private MenuPage _menuPage;
        public MainWindow()
        {
            InitializeComponent();
            _menuPage = new MenuPage(this);
            Main.Navigate(_menuPage);
        }

        private void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
