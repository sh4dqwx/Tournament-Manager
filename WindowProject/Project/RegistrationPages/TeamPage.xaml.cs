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
        public TeamPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        public void refreshTeams()
        {
            string names = "";
            string category = "";
            List<Team> teams = _menu.volleyball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Siatkówka\n"; });
            teams = _menu.tugOfWar.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Przeciąganie liny\n"; });
            teamName.Text = names;
            teamCategory.Text = category;
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void addTeamButton(object sender, RoutedEventArgs e)
        {
            if (addTeamName.Text.Length == 0) return;
            switch (addCategoryName.SelectedIndex)
            {
                case 0:
                    _menu.volleyball.addTeam(new Team(addTeamName.Text));
                    break;
                case 1:
                    _menu.tugOfWar.addTeam(new Team(addTeamName.Text));
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            addTeamName.Text = "";
            addCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }

        private void removeTeamButton(object sender, RoutedEventArgs e)
        {
            if (removeTeamName.Text.Length == 0) return;
            switch (removeCategoryName.SelectedIndex)
            {
                case 0:
                    _menu.volleyball.removeTeam(new Team(removeTeamName.Text));
                    break;
                case 1:
                    _menu.tugOfWar.removeTeam(new Team(removeTeamName.Text));
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            removeTeamName.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
