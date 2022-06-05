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
using Project.Interface;
using Project.Logic;
using Project.Logic.Registrations;
using Project.Logic.Tournaments;
namespace Project.Interface
{
    public partial class Results : Page
    {
        private Tournament tournament;
        private MenuPage _menu;
        public Results(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }
        public void loadResults(Tournament tournament)
        {
            this.tournament = tournament;
            teamsList.ItemsSource = tournament.getResults();
        }
        private void Go_menu(object sender, RoutedEventArgs e)
        {
            teamsList.SelectedIndex = -1;
            NavigationService.Navigate(_menu);
        }
        private void TeamResult(object sender, SelectionChangedEventArgs e)
        {
            if (teamsList.SelectedIndex == -1) return;
            TeamInfo.Text = "";
            Team team = tournament.getTeam(teamsList.SelectedIndex);
            TeamInfo.Text += "Nazwa drużyny: " + team.getName() + "\n";
            TeamInfo.Text += "Zajęte miejsce :"+ team.getPlace().ToString()+"\n";
            TeamInfo.Text += "Wygranych spotkań :" + team.getWin().ToString() + "\n";
            TeamInfo.Text += "Przegranych spotkań :" + team.getLost().ToString() + "\n";
        }
    }
}
