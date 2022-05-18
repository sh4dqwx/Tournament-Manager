using Project.Logic;
using System;
using System.Windows.Controls;

namespace Project
{
    public partial class RegistrationPage : Page
    {
        private MenuPage _menu;
        private Tournament tournament;
        private JudgePage judgePage;
        public RegistrationPage(MenuPage _menu)
        {
            this._menu = _menu;
            InitializeComponent();
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
        }

        public void buttonPressed()
        {
            judgePage.loadTournament(tournament);
            NavigationService.Navigate(judgePage);
        }
    }
}
