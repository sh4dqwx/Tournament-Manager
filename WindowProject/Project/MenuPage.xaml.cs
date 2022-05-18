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
            tournamentsList.ItemsSource = program.getTournamentList();
        }
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            program = new Program();
            program.addTournament(new Volleyball("a"));
            program.addTournament(new TugOfWar("a"));
            program.addTournament(new Dodgeball("a"));
            refresh();
            _window = window;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            program.addTournament(new TugOfWar("b"));
            refresh();
        }
    }
}
