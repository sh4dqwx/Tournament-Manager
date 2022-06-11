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
using Project.Logic;
using Project.Logic.Registrations;
using Project.Logic.Tournaments;
using Project.Exceptions;

namespace Project.Interface
{
    public partial class TeamPage : Page
    {
        private Tournament tournament;
        private PlayersPage playersPage;
        private RegistrationPage _reg;
        public TeamPage(RegistrationPage reg)
        {
            InitializeComponent();
            _reg = reg;
            playersPage = new PlayersPage(this);
        }
        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            refreshTeams();
        }
        private void refreshTeams()
        {
            addTeamName.Text = "";
            removeTeamName.Text = "";
            string captains="";
            string names = "";
            string[] teams = tournament.getTeams();
            string[] captain = tournament.getCaptain();
            for (int i = 0; i < teams.Length; i++)
            {
                names += teams[i] + "\n";
                captains+=captain[i] + "\n";
            }
            teamCaptain.Text = captains;
            teamName.Text = names;
        }
        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_reg);
        }
        private void addPlayerButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(playersPage);
            addButton.IsEnabled = true;
        }
        private void addTeamButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (addTeamName.Text.Length == 0) throw new EmptyStringException("Podaj nazwę drużyny");
                Player[] players = playersPage.getPlayers();
                tournament.addTeam(new Team(players, addTeamName.Text));
            }
            catch(EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshTeams();
                return;
            }
            catch(TeamExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Drużyna {ex.getName()} już istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshTeams();
                return;
            }
            addButton.IsEnabled = false;
            playersPage.clearBoxes();
            refreshTeams();
        }

        private void removeTeamButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (removeTeamName.Text.Length == 0) throw new EmptyStringException("Podaj nazwę drużyny");
                tournament.removeTeam(new Team(removeTeamName.Text));
            }
            catch(EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshTeams();
                return;
            }
            catch(TeamNotExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Drużyna {ex.getName()} nie istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshTeams();
                return;
            }
            refreshTeams();
        }
    }
}
