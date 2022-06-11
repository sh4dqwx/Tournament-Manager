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
using Project.Exceptions;

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
        }
        private void refreshButtons()
        {
            if (tournament.getState() == 4 && tournament.isAllPlayed()) showResultsButton.IsEnabled = true;
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

            if (tournament is Volleyball) secondaryJudgesGrid.Visibility = Visibility.Visible;
            judgeGrid.Visibility = Visibility.Visible;

            if (isFinished)
            {
                setFinishedGame();
                setChosenJudges();
            }
            else
            {
                setNotFinishedGame();
                setNotChosenJudges();
            }
        }
        private void setNotFinishedGame()
        {
            radioFirst.IsChecked = false;
            radioSecond.IsChecked = false;
            radioFirst.Focusable = true;
            radioSecond.Focusable = true;
            radioFirst.IsHitTestVisible = true;
            radioSecond.IsHitTestVisible = true;
            confirmButton.IsEnabled = true;
        }
        private void setFinishedGame()
        {
            if(selectedGame.getFirstTeam().Equals(selectedGame.getWinner())) radioFirst.IsChecked = true;
            else radioSecond.IsChecked = true;
            radioFirst.Focusable = false;
            radioSecond.Focusable = false;
            radioFirst.IsHitTestVisible = false;
            radioSecond.IsHitTestVisible = false;
            confirmButton.IsEnabled = false;
        }
        private void setNotChosenJudges()
        {
            judgeComboBox.ItemsSource = tournament.getJudgeList();
            judgeComboBox.IsEnabled = true;

            secondaryJudge1ComboBox.ItemsSource = tournament.getJudgeList();
            secondaryJudge1ComboBox.IsEnabled = true;

            secondaryJudge2ComboBox.ItemsSource = tournament.getJudgeList();
            secondaryJudge2ComboBox.IsEnabled = true;
        }
        private void setChosenJudges()
        {
            JudgeDisplay[] mainJudge = new JudgeDisplay[1];
            mainJudge[0] = new JudgeDisplay(selectedGame.getMainJudge());
            judgeComboBox.ItemsSource = mainJudge;
            judgeComboBox.SelectedIndex = 0;
            judgeComboBox.IsEnabled = false;

            if (selectedGame.getSecondaryJudge1() is null) return;

            JudgeDisplay[] secondaryJudge1 = new JudgeDisplay[1];
            secondaryJudge1[0] = new JudgeDisplay(selectedGame.getSecondaryJudge1());
            secondaryJudge1ComboBox.ItemsSource = secondaryJudge1;
            secondaryJudge1ComboBox.SelectedIndex = 0;
            secondaryJudge1ComboBox.IsEnabled = false;

            JudgeDisplay[] secondaryJudge2 = new JudgeDisplay[1];
            secondaryJudge2[0] = new JudgeDisplay(selectedGame.getSecondaryJudge2());
            secondaryJudge2ComboBox.ItemsSource = secondaryJudge2;
            secondaryJudge2ComboBox.SelectedIndex = 0;
            secondaryJudge2ComboBox.IsEnabled = false;
        }
        private void hideGame()
        {
            selectedFirst.Content = "";
            selectedSecond.Content = "";
            radioFirst.Visibility = Visibility.Hidden;
            radioSecond.Visibility = Visibility.Hidden;
            confirmButton.Visibility = Visibility.Hidden;
            judgeGrid.Visibility = Visibility.Hidden;
            secondaryJudgesGrid.Visibility = Visibility.Hidden;
            judgeComboBox.ItemsSource = null;
            secondaryJudge1ComboBox.ItemsSource = null;
            secondaryJudge2ComboBox.ItemsSource = null;
        }
        private void showElimination()
        {
            gameplayPhase.Content = "Eliminacje";
            refreshList();
            refreshButtons();
            hideGame();
        }
        private void showSemiFinal()
        {
            gameplayPhase.Content = "Półfinał";
            refreshList();
            refreshButtons();
            hideGame();
        }
        private void showFinal()
        {
            gameplayPhase.Content = "Finał";
            refreshList();
            refreshButtons();
            hideGame();
        }
        private bool isJudgeChosen()
        {
            if (tournament is Volleyball && judgeComboBox.SelectedIndex == -1 && secondaryJudge1ComboBox.SelectedIndex == -1 && secondaryJudge2ComboBox.SelectedIndex == -1) return false;
            if (judgeComboBox.SelectedIndex == -1) return false;
            return true;
        }
        public GameplayPage(MenuPage menu, Results resultsPage)
        {
            InitializeComponent();
            _menu = menu;
            _results = resultsPage;
            showResultsButton.IsEnabled = false;
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            switch (tournament.getState())
            {
                case 1:
                    tournament.prepareElimination();
                    showElimination();
                    break;
                case 2:
                    showElimination();
                    break;
                case 3:
                    showSemiFinal();
                    break;
                case 4:
                    showFinal();
                    break;
            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (radioFirst.IsChecked == false && radioSecond.IsChecked == false) throw new TeamNotCheckedException("Wybierz wygraną drużynę");
                if (!isJudgeChosen()) throw new JudgesNotChosenException("Wybierz sędziów");
                if (radioFirst.IsChecked == true) selectedGame.playManual(1);
                else selectedGame.playManual(2);
                if (tournament is Volleyball) selectedGame.setJudges(tournament.getJudge(judgeComboBox.SelectedIndex), tournament.getJudge(secondaryJudge1ComboBox.SelectedIndex), tournament.getJudge(secondaryJudge2ComboBox.SelectedIndex));
                else selectedGame.setJudges(tournament.getJudge(judgeComboBox.SelectedIndex));
                refreshList();
                refreshButtons();
                hideGame();
            }
            catch(TeamNotCheckedException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch(JudgesNotChosenException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void RandomScore_Button(object sender, RoutedEventArgs e)
        {
            tournament.playRandom();
            refreshList();
            refreshButtons();
            hideGame();
        }
        private void Next_Button(object sender, RoutedEventArgs e)
        {
            switch (tournament.getState())
            {
                case 2:
                    tournament.prepareSemiFinal();
                    showSemiFinal();
                    break;
                case 3:
                    tournament.prepareFinal();
                    showFinal();
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
