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

namespace Project.Interface
{
    /// <summary>
    /// Logika interakcji dla klasy GameplayPage.xaml
    /// </summary>
    public partial class GameplayPage : Page
    {
        private MenuPage _menu;
        private Tournament tournament;
        public GameplayPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            gamesList.ItemsSource = tournament.getGames();
        }
    }
}
