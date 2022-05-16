using System;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window _window;
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }
    }
}
