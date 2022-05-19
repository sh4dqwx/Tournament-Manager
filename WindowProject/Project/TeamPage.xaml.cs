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
namespace Project
{
    public partial class TeamPage : Page
    {
        private List<Player> player = new List<Player>();
        private RegistrationPage _reg;
        private Tournament tournament;
        public TeamPage(RegistrationPage reg)
        {
            InitializeComponent();
            _reg = reg;
        }
        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            refreshTeams();
        }
        public void refreshTeams()
        {
            string names = "";
            string[] teams = tournament.getTeams();
            for (int i = 0; i < teams.Length; i++)
            {
                names += teams[i] + "\n";
            }
            teamName.Text = names;
        }
        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_reg);
        }
        private void addTeamButton(object sender, RoutedEventArgs e)
        {
            player.Add(new Player("Jakub", "Modzelewski"));
            player.Add(new Player("Jan", "Testowy"));
            tournament.addTeam(new Team(player,addTeamName.Text));
            addTeamName.Text = "";
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
