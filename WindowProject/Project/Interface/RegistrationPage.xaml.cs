using System;
using System.Windows.Controls;
using Project.Logic.Tournaments;

namespace Project.Interface
{
    public partial class RegistrationPage : Page
    {
        private MenuPage _menu;
        private GameplayPage _gameplay;
        private Tournament tournament;
        private JudgePage judgePage;
        private TeamPage teamPage;
        public RegistrationPage(MenuPage menu, GameplayPage gameplay)
        {
            InitializeComponent();
            _menu = menu;
            _gameplay = gameplay;
            judgePage = new JudgePage(this);
            teamPage = new TeamPage(this);
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
            teamPage.loadTournament(tournament);
            NavigationService.Navigate(teamPage);
        }

        private void Judge_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            judgePage.loadTournament(tournament);
            NavigationService.Navigate(judgePage);
        }

        private void Play_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(_gameplay);
        }
    }
}
