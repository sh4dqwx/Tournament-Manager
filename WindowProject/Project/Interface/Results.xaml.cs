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
using Project.Logic.Tournaments;
namespace Project.Interface
{
    public partial class Results : Page
    {
        private Tournament tournament;
        private GameplayPage _gamePage;
        public Results(GameplayPage gamePage)
        {
            InitializeComponent();
            _gamePage = gamePage;
        }
        public void loadResults(Tournament tournament)
        {
            tournament = tournament;
            teamsList.ItemsSource = tournament.getResults();
        }
    }
}
