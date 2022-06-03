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
        private Tournament tournament;
        private Game selectedGame;
        public GameplayPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            tournament.generateElimination();
            gamesList.ItemsSource = tournament.getGameList();
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (radioFirst.IsChecked == false && radioSecond.IsChecked == false) return;
            if (selectedGame == null) return;
            if (radioFirst.IsChecked == true) selectedGame.playManual(1);
            else selectedGame.playManual(2);
        }
        private void RandomScore_Button(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void showGame(object sender, SelectionChangedEventArgs e)
        {
            if (gamesList.SelectedIndex == -1) return;
            selectedGame = tournament.getGame(gamesList.SelectedIndex);
            selectedFirst.Content = selectedGame.getFirstTeam().getName();
            selectedSecond.Content = selectedGame.getSecondTeam().getName();
            radioFirst.Visibility = Visibility.Visible;
            radioFirst.IsChecked = false;
            radioSecond.Visibility = Visibility.Visible;
            radioSecond.IsChecked = false;
        }
    }
}
