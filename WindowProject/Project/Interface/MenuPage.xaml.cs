using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Project.Logic;
using Project.Logic.Tournaments;
using Project.Exceptions;

namespace Project.Interface
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private RegistrationPage registrationPage;
        private GameplayPage gameplayPage;
        private Results resultsPage;
        private Program program;
        private string savedFolderPath;

        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            resultsPage = new Results(this);
            gameplayPage = new GameplayPage(this, resultsPage);
            registrationPage = new RegistrationPage(this, gameplayPage);
            program = new Program();
            savedFolderPath = getSavedFolderPath();
            refresh();
        }

        private string getSavedFolderPath()
        {
            string[] folders = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            string folderPath = "";
            for (int i = 0; i < folders.Length - 4; i++)
            {
                folderPath += $@"{folders[i]}\";
            }
            folderPath += "saved";
            return folderPath;
        }
        private void refresh()
        {
            tournamentList.ItemsSource = program.getTournamentList();
            addTournamentName.Text = "";
            removeTournamentName.Text = "";
            addTournamentCategory.SelectedIndex = 0;
            removeTournamentCategory.SelectedIndex = 0;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if(addTournamentName.Text.Length == 0) throw new EmptyStringException("Podaj nazwę turnieju");
                program.addTournament(program.newTournament(addTournamentName.Text, addTournamentCategory.SelectedItem.ToString().Remove(0,38)));
                refresh();
            }
            catch(EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refresh();
                return;
            }
            catch(TournamentExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Turniej {ex.getName()} w kategorii {ex.getCategory()} już istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refresh();
                return;
            }
        }
        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (removeTournamentName.Text.Length == 0) throw new EmptyStringException("Podaj nazwę turnieju");
                program.removeTournament(program.newTournament(removeTournamentName.Text, removeTournamentCategory.SelectedItem.ToString().Remove(0,38)));
                refresh();
            }
            catch (EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refresh();
                return;
            }
            catch(TournamentNotExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Turniej {ex.getName()} w kategorii {ex.getCategory()} nie istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refresh();
                return;
            }
        }
        private void Load_Button(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.InitialDirectory = savedFolderPath;
            loadFile.Filter = "txt files (*.txt)|*.txt";
            loadFile.CheckFileExists = true;

            if (loadFile.ShowDialog() == false) return;
            program.load(loadFile.FileName);
            refresh();
        }
        private void Save_Button(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = savedFolderPath;
            saveFile.Filter = "txt files (*.txt)|*.txt";

            if (saveFile.ShowDialog() == false) return;
            program.save(saveFile.FileName);
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }

        private void moveToTournament(object sender, SelectionChangedEventArgs e)
        {
            if (tournamentList.SelectedIndex == -1) return;
            Tournament selectedT = program.getTournament(tournamentList.SelectedIndex);
            switch(selectedT.getState())
            {
                case 1:
                    registrationPage.loadTournament(selectedT);
                    NavigationService.Navigate(registrationPage);
                    break;
                case 2:
                case 3:
                case 4:
                    gameplayPage.loadTournament(selectedT);
                    NavigationService.Navigate(gameplayPage);
                    break;
                case 5:
                    resultsPage.loadResults(selectedT);
                    NavigationService.Navigate(resultsPage);
                    break;
            }
            tournamentList.SelectedIndex = -1;
        }
    }
}
