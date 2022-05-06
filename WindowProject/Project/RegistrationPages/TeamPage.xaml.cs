using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Project.Registrations;

namespace Project.RegistrationPages
{
    public partial class TeamPage : Page
    {
        private MenuPage _menu;
        private TeamManager teamManager;
        private List<Team> teams;
        public TeamPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
            teamManager = new TeamManager();
        }

        public void refreshTeams()
        {
            string names = "";
            string category = "";
            teams = _menu.volleyball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Siatkówka\n"; });
            teams = _menu.tugOfWar.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Przeciąganie liny\n"; });
            teams = _menu.dodgeball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Dwa ognie\n"; });
            teamName.Text = names;
            teamCategory.Text = category;
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void addTeamButton(object sender, RoutedEventArgs e)
        {
            teamManager.addTeam(_menu, addTeamName.Text, addCategoryName.SelectedIndex);
            addTeamName.Text = "";
            addCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }

        private void removeTeamButton(object sender, RoutedEventArgs e)
        {
            teamManager.removeTeam(_menu, removeTeamName.Text, removeCategoryName.SelectedIndex);
            removeTeamName.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
