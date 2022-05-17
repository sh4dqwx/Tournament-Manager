using System;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window _window;
        private Program program;
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            program = new Program();
            _window = window;
        }
    }
}
