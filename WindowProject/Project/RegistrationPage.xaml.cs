using System;
using System.Windows.Controls;
using Project.Logic;

namespace Project
{
    public partial class RegistrationPage : Page
    {
        private MenuPage _menu;
        private Tournament tournament;
        private JudgePage judgePage;
        public RegistrationPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
            judgePage = new JudgePage(this);
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            Title.Content = tournament.getName();
        }

        private void Exit_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void Team_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            //Nie ma strony teamPage
        }

        private void Judge_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            judgePage.loadTournament(tournament);
            NavigationService.Navigate(judgePage);
        }

        private void Play_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            //Nie ma strony rozgrywek
        }
    }
}
