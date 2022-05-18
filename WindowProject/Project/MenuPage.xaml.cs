using System.Windows;
using System.Windows.Controls;
using Project.Logic;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private Program program;
        private void refresh()
        {
            tournamentList.ItemsSource = program.getTournamentList();
        }
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            program = new Program();
            refresh();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            program.addTournament(addTournamentName.Text, addTournamentCategory.SelectedIndex);
            addTournamentName.Text = "";
            addTournamentCategory.SelectedIndex = 0;
            refresh();
        }
        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            program.removeTournament(removeTournamentName.Text, removeTournamentCategory.SelectedIndex);
            removeTournamentName.Text = "";
            removeTournamentCategory.SelectedIndex = 0;
            refresh();
        }
        private void Load_Button(object sender, RoutedEventArgs e)
        {

        }
        private void Save_Button(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }

        private void moveToTournament(object sender, SelectionChangedEventArgs e)
        {
            Tournament t = program.getTournament(tournamentList.SelectedIndex);
            MessageBoxResult result = MessageBox.Show(t.getName(), "yes", MessageBoxButton.OK);
        }
    }
}
