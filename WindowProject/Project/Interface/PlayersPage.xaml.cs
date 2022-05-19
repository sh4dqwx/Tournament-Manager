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
using Project.Logic.Registrations;

namespace Project.Interface
{
    public partial class PlayersPage : Page
    {
        private TeamPage _team;
        private List<Player> player = new List<Player>();
        public PlayersPage(TeamPage team)
        {
            InitializeComponent();
            _team = team;
        }
        public void loadPlayers(List<Player> players)
        {
            player = players;
        }
        public void createTeamButton(object sender, RoutedEventArgs e)
        {
            player.Add(new Player(addCaptain.Text, addCaptainS.Text));
            player.Add(new Player(player1.Text, player1S.Text));
            player.Add(new Player(player2.Text, player2S.Text));
            player.Add(new Player(player3.Text, player3S.Text));
            player.Add(new Player(player4.Text, player4S.Text));
            addCaptain.Text = "";
            addCaptainS.Text = "";
            player1.Text = "";
            player1S.Text = "";
            player2.Text = "";
            player2S.Text = "";
            player3.Text = "";
            player3S.Text = "";
            player4.Text = "";
            player4S.Text = "";
            NavigationService.Navigate(_team);
        }
    }
}
