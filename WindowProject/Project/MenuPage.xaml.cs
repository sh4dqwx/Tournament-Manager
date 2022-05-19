using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using Project.Logic;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private RegistrationPage registrationPage;
        private Program program;
        private string savedFolderPath;
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
        }
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            registrationPage = new RegistrationPage(this);
            program = new Program();
            savedFolderPath = getSavedFolderPath();
            refresh();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            if (addTournamentName.Text.Length == 0) return;
            program.addTournament(addTournamentName.Text, addTournamentCategory.SelectedValue.ToString());
            addTournamentName.Text = "";
            addTournamentCategory.SelectedIndex = 0;
            refresh();
        }
        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            if (removeTournamentName.Text.Length == 0) return;
            program.removeTournament(removeTournamentName.Text, removeTournamentCategory.SelectedValue.ToString());
            removeTournamentName.Text = "";
            removeTournamentCategory.SelectedIndex = 0;
            refresh();
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
            Tournament t = program.getTournament(tournamentList.SelectedIndex);
            registrationPage.loadTournament(t);
            NavigationService.Navigate(registrationPage);
        }
    }
}
