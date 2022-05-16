using System;
using System.Windows;

namespace Project.GamePages
{

    public partial class Content : Window
    {
        public Content(string text)
        {
            InitializeComponent();
            contestPlace.Text = text;
        }
    }
}
