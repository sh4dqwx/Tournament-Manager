using System.Windows;
using System.Windows.Controls;
using Project.Logic;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window _window;
        private Program program;
        private void refresh()
        {
            tournamentsList.ItemsSource = program.getTournaments();
        }
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            program = new Program();
            program.addTournament("a");
            program.addTournament("a");
            program.addTournament("a");
            tournamentsList.ItemsSource = program.getTournaments();
            _window = window;
        }
    }
}
