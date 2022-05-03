using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using Project.Registrations;
namespace Project.GamePages
{
    public partial class VolleyballPage : Page
    {
        private MenuPage _menu;
        public VolleyballPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }
        public void refreshPoints()
        {
            int lp = 1;
            string place = "";
            string names = "";
            string points = "";
            List<Team> teams = _menu.volleyball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; points += team.getScore() + "\n"; place += lp + "\n";lp += 1; });
            teamPlace.Text = place;
            teamName.Text = names;
            teamPoints.Text = points;
        }
        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }
        private void ShowTeams_Button(object sender, RoutedEventArgs e)
        {
            if(_menu.volleyball.getTeams().Count <= 4)
            {
               MessageBox.Show("Za mało drużyn minimalna liczba to 5", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            HEl.IsEnabled = true;
            HRo.IsEnabled = false;
            refreshPoints();
        }
        private void Elimination_Button(object sender, RoutedEventArgs e)
        {
            HCw.IsEnabled = true;
            HEl.IsEnabled = false;

            string score =_menu.volleyball.playElimination();
            Content content = new Content(score);
            content.Show();
            refreshPoints();
        }
        private void Semi_Button(object sender, RoutedEventArgs e)
        {
            HFi.IsEnabled = true;
            HCw.IsEnabled = false;

            string score = _menu.volleyball.playSemiFinal();
            Content content2 = new Content(score);
            content2.Show();
            refreshPoints();

        }
        private void Final_Button(object sender, RoutedEventArgs e)
        {
            HFi.IsEnabled = false;
            HRo.IsEnabled = true;

            string score=_menu.volleyball.playFinal();
            Content content3 = new Content(score);
            content3.Show();
            refreshPoints();
        }
    }
}
