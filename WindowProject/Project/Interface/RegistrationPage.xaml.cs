using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Project.Logic.Tournaments;
using Project.Exceptions;

namespace Project.Interface
{
    public partial class RegistrationPage : Page
    {
        private MenuPage _menu;
        private GameplayPage gameplayPage;
        private Tournament tournament;
        private JudgePage judgePage;
        private TeamPage teamPage;
        public RegistrationPage(MenuPage menu, GameplayPage gameplay)
        {
            InitializeComponent();
            _menu = menu;
            gameplayPage = gameplay;
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
            try
            {
                gameplayPage.loadTournament(tournament);
                NavigationService.Navigate(gameplayPage);
            }
            catch (NotEnoughTeamsException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (NotEnoughJudgesException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }   
        }
    }
}
