using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Win32;
using Project.RegistrationPages;
using Project.Registrations;
using Project.Games;
using Project.GamePages;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private TeamPage teamPage;
        private JudgePage judgePage;
        private VolleyballPage volleyballPage;
        private TugOfWarPage tugOfWarPage;
        private DodgeballPage dodgeballPage;
        public Volleyball volleyball = new Volleyball();
        public Tug_of_war tugOfWar = new Tug_of_war();
        public Dodgeball dodgeball = new Dodgeball();

        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            teamPage = new TeamPage(this);
            judgePage = new JudgePage(this);
            volleyballPage = new VolleyballPage(this);
            tugOfWarPage = new TugOfWarPage(this);
            dodgeballPage = new DodgeballPage(this);
        }

        private void TeamButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(teamPage);
        }

        private void JudgeButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(judgePage);
        }

        private void LoadButton_Clicked(object sender, RoutedEventArgs e)
        {
            string[] folders = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            string folderPath = "";
            for (int i = 0; i < folders.Length - 4; i++)
            {
                folderPath += $@"{folders[i]}\";
            }
            folderPath += "saved";

            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.InitialDirectory = folderPath;
            loadFile.Filter = "txt files (*.txt)|*.txt";
            loadFile.CheckFileExists = true;

            if (loadFile.ShowDialog() == false) return;

            volleyball.clearTeams();
            volleyball.clearJudges();
            tugOfWar.clearTeams();
            tugOfWar.clearJudges();

            StreamReader loadStream = new StreamReader(loadFile.FileName);
            while (!loadStream.EndOfStream)
            {
                string[] dane = loadStream.ReadLine().Split(',');
                if (dane[0].Equals("T"))
                {
                    if (dane[1].Equals("V"))
                    {
                        volleyball.addTeam(new Team(dane[2]));
                    }
                    else if (dane[1].Equals("T"))
                    {
                        tugOfWar.addTeam(new Team(dane[2]));
                    }
                }
                else if (dane[0].Equals("J"))
                {
                    if (dane[1].Equals("V"))
                    {
                        volleyball.addJudge(new Judge(dane[3], dane[2]));
                    }
                    else if (dane[1].Equals("T"))
                    {
                        tugOfWar.addJudge(new Judge(dane[3], dane[2]));
                    }
                }
            }
            loadStream.Close();
            refreshTables();
        }

        private void VolleyballButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(volleyballPage);
        }

        private void TugOfWarButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(tugOfWarPage);
        }

        private void DodgeballButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(dodgeballPage);
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy zapisać stan programu?", "Wyjście", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            { 
                string[] folders = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
                string folderPath = "";
                for(int i=0; i<folders.Length-4; i++)
                {
                    folderPath += $@"{folders[i]}\";
                }
                folderPath += "saved";
         
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = folderPath;
                saveFile.Filter = "txt files (*.txt)|*.txt";

                if (saveFile.ShowDialog() == false) return;
                StreamWriter saveStream = new StreamWriter(saveFile.FileName);
                volleyball.getTeams().ForEach(team =>
                {
                    saveStream.WriteLine($"T,V,{team.getName()}");
                });                
                tugOfWar.getTeams().ForEach(team =>
                {
                    saveStream.WriteLine($"T,T,{team.getName()}");
                });
                volleyball.getJudges().ForEach(judge =>
                {
                    saveStream.WriteLine($"J,V,{judge.getSurname()},{judge.getName()}");
                });
                tugOfWar.getJudges().ForEach(judge =>
                {
                    saveStream.WriteLine($"J,T,{judge.getSurname()}, {judge.getName()}");
                });
                saveStream.Close();                   
            }
            mainWindow.Close();
        }

        public void refreshTables()
        {
            teamPage.refreshTeams();
            judgePage.refreshJudges();
            volleyballPage.refreshPoints();
            tugOfWarPage.refreshPoints();
            dodgeballPage.refreshPoints();
        }
    }
}
