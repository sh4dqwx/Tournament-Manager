using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Logic.Tournaments;
using Project.Logic.Registrations;

namespace Project.Interface
{
    /// <summary>
    /// Logika interakcji dla klasy GameplayPage.xaml
    /// </summary>
    public partial class GameplayPage : Page
    {
        private MenuPage _menu;
        private Results _results;
        private Tournament tournament;
        private Game selectedGame;
        private void refreshList()
        {
            gamesList.ItemsSource = tournament.getGameList();
            if(tournament.getState() == 4 && tournament.isAllPlayed()) showResultsButton.IsEnabled = true;
            else if (tournament.isAllPlayed()) nextButton.IsEnabled = true;
            else nextButton.IsEnabled = false;
        }
        private void showGame(bool isFinished)
        {
            selectedFirst.Content = selectedGame.getFirstTeam().getName();
            selectedSecond.Content = selectedGame.getSecondTeam().getName();
            radioFirst.Visibility = Visibility.Visible;
            radioSecond.Visibility = Visibility.Visible;
            confirmButton.Visibility = Visibility.Visible;
            if(isFinished) showFinishedGame();
            else showNotFinishedGame();
        }
        private void showNotFinishedGame()
        {
            radioFirst.IsChecked = false;
            radioSecond.IsChecked = false;
            radioFirst.Focusable = true;
            radioSecond.Focusable = true;
            radioFirst.IsHitTestVisible = true;
            radioSecond.IsHitTestVisible = true;
            confirmButton.IsEnabled = true;
        }
        private void showFinishedGame()
        {
            if(selectedGame.getFirstTeam().Equals(selectedGame.getWinner())) radioFirst.IsChecked = true;
            else radioSecond.IsChecked = true;
            radioFirst.Focusable = false;
            radioSecond.Focusable = false;
            radioFirst.IsHitTestVisible = false;
            radioSecond.IsHitTestVisible = false;
            confirmButton.IsEnabled = false;
        }
        private void hideGame()
        {
            selectedFirst.Content = "";
            selectedSecond.Content = "";
            radioFirst.Visibility = Visibility.Hidden;
            radioSecond.Visibility = Visibility.Hidden;
            confirmButton.Visibility = Visibility.Hidden;
        }
        private void prepareElimination()
        {
            gameplayPhase.Content = "Eliminacje";
            tournament.prepareElimination();
            refreshList();
            hideGame();
        }
        private void prepareSemiFinal()
        {
            gameplayPhase.Content = "Półfinał";
            tournament.prepareSemiFinal();
            refreshList();
            hideGame();
        }
        private void prepareFinal()
        {
            gameplayPhase.Content = "Finał";
            tournament.prepareFinal();
            refreshList();
            hideGame();
        }

        public GameplayPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
            _results = new Results(this);
            showResultsButton.IsEnabled = false;
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            switch(tournament.getState())
            {
                case 1:
                    prepareElimination();
                    break;
                case 2:
                    gameplayPhase.Content = "Eliminacje";
                    refreshList();
                    hideGame();
                    break;
                case 3:
                    gameplayPhase.Content = "Półfinały";
                    refreshList();
                    hideGame();
                    break;
                case 4:
                    gameplayPhase.Content = "Finał";
                    refreshList();
                    hideGame();
                    break;
            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (radioFirst.IsChecked == false && radioSecond.IsChecked == false) return;
            if (selectedGame is null) return;
            if (radioFirst.IsChecked == true) selectedGame.playManual(1);
            else selectedGame.playManual(2);
            refreshList();
            hideGame();
        }
        private void RandomScore_Button(object sender, RoutedEventArgs e)
        {
            tournament.playRandom();
            refreshList();
            hideGame();
        }
        private void Next_Button(object sender, RoutedEventArgs e)
        {
            switch (tournament.getState())
            {
                case 2:
                    prepareSemiFinal();
                    break;
                case 3:
                    prepareFinal();
                    break;
                case 4:
                    showResultsButton.IsEnabled = true;
                    break;
            }
        }
        private void ShowResults_Button(object sender, RoutedEventArgs e)
        {
            tournament.finalResult();
            _results.loadResults(tournament);
            NavigationService.Navigate(_results);
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void OnClick(object sender, SelectionChangedEventArgs e)
        {
            if (gamesList.SelectedIndex == -1) return;
            selectedGame = tournament.getGame(gamesList.SelectedIndex);
            if (selectedGame.getWinner() is null) showGame(false);
            else showGame(true);
        }
    }
}
