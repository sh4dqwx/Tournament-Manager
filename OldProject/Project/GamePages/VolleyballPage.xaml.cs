using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using Project.Registrations;
using Project.Exceptions;

namespace Project.GamePages
{
    public partial class VolleyballPage : Page
    {
        private MenuPage _menu;
        private Content content;
        public VolleyballPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        //Odświeżanie tablicy drużyn i wyników
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

        //Przycisk powrotu do menu
        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            if (content != null) content.Close();
            NavigationService.Navigate(_menu);
        }

        //Przyciski do wywoływania metod przeprowadzających turniej
        private void ShowTeams_Button(object sender, RoutedEventArgs e)
        {
            if (content != null) content.Close();

            try { if (_menu.volleyball.getTeams().Count <= 4) throw new NotEnoughException("Za mało drużyn, minimalna liczba to 5"); }
            catch(NotEnoughException ex)
            {
                MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            HEl.IsEnabled = true;
            HRo.IsEnabled = false;
            _menu.refreshTables();
        }
        private void Elimination_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string score = _menu.volleyball.playElimination();
                content = new Content(score);
                content.Show();
            }
            catch(NotEnoughException ex)
            {
                MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            HCw.IsEnabled = true;
            HEl.IsEnabled = false;
            _menu.refreshTables();
        }
        private void Semi_Button(object sender, RoutedEventArgs e)
        {
            HFi.IsEnabled = true;
            HCw.IsEnabled = false;

            string score = _menu.volleyball.playSemiFinal();
            content.Close();
            content = new Content(score);
            content.Show();
            _menu.refreshTables();

        }
        private void Final_Button(object sender, RoutedEventArgs e)
        {
            HFi.IsEnabled = false;
            HRo.IsEnabled = true;

            string score=_menu.volleyball.playFinal();
            content.Close();
            content = new Content(score);
            content.Show();
            _menu.refreshTables();
        }
    }
}
