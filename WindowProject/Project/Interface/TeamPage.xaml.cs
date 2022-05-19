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

namespace Project.Interface
{
    public partial class TeamPage : Page
    {
        private List<Player> player = new List<Player>();
        private RegistrationPage _reg;
        private Tournament tournament;
        private PlayersPage playersPage;
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
        public void refreshTeams()
        {
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
            playersPage.loadPlayers(player);
            NavigationService.Navigate(playersPage);
            addButton.IsEnabled = true;
        }
        private void addTeamButton(object sender, RoutedEventArgs e)
        {
            tournament.addTeam(new Team(player,addTeamName.Text));
            addTeamName.Text = "";
            addButton.IsEnabled = false;
            refreshTeams();
        }

        private void removeTeamButton(object sender, RoutedEventArgs e)
        {
            tournament.removeTeam(new Team(player,removeTeamName.Text));
            removeTeamName.Text = "";
            refreshTeams();
        }
    }
}
