using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using Project.Games;
using Project.Registrations;
namespace Project.GamePages
{
    public partial class VolleyballPage : Page
    {
        private MenuPage _menu;
        private int x = 0;
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
            x = 1;
            refreshPoints();
        }
        private void Elimination_Button(object sender, RoutedEventArgs e)
        {
            if (x == 1)
            {
                x = 2;

                string score =_menu.volleyball.playElimination();
                Content content = new Content(score);
                content.Show();
                refreshPoints();
            }
            else
            {
                MessageBoxResult info = MessageBox.Show("Najpierw wybierz 'Pokaż drużyny'", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Semi_Button(object sender, RoutedEventArgs e)
        {
            if (x == 2)
            {
                x = 3;
                _menu.volleyball.playSemiFinal();
                refreshPoints();
            }
            else
            {
                MessageBoxResult info = MessageBox.Show("Najpierw wybierz 'Eliminacje'", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Final_Button(object sender, RoutedEventArgs e)
        {
            if (x == 3)
            {
                _menu.volleyball.playFinal();
                refreshPoints();
            }
            else
            {
                MessageBoxResult info = MessageBox.Show("Najpierw wybierz 'Ćwierćfinały'", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
