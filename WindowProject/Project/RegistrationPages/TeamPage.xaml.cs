using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Project.Registrations;
using Project.Exceptions;

namespace Project.RegistrationPages
{
    public partial class TeamPage : Page
    {
        private MenuPage _menu;
        private TeamManager teamManager;
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
            List<Team> teams = _menu.volleyball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Siatkówka\n"; });
            teams = _menu.tugOfWar.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Przeciąganie liny\n"; });
            teams = _menu.dodgeball.getTeams();
            teams.ForEach(team => { names += team.getName() + "\n"; category += "Dwa ognie\n"; });
            teamName.Text = names;
            teamCategory.Text = category;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void AddTeam_Button(object sender, RoutedEventArgs e)
        {
            try { teamManager.addTeam(_menu, addTeamName.Text, addCategoryName.SelectedIndex); }
            catch(EmptyNameException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(AddExistentTeamException ex)
            {
                MessageBoxResult error = MessageBox.Show(
                    $"Drużyna {ex.getTeamName()} w kategorii {ex.getTeamCategory()} już istnieje", 
                    "UWAGA", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error
                );
            }
            addTeamName.Text = "";
            addCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }

        private void RemoveTeam_Button(object sender, RoutedEventArgs e)
        {
            try { teamManager.removeTeam(_menu, removeTeamName.Text, removeCategoryName.SelectedIndex); }
            catch (EmptyNameException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            removeTeamName.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
