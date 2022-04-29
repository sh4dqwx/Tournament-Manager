using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Project.Registration;
using Project.Sports;

namespace Project
{
    public partial class MenuPage : Page
    {
        private Window mainWindow;
        private VolleyballPage volleyball;
        private TugOfWarPage tugOfWar;
        public MenuPage(MainWindow window)
        {
            InitializeComponent();
            volleyball = new VolleyballPage(this);
            tugOfWar = new TugOfWarPage(this);
            mainWindow = window;
        }
        private void Volleyball_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(volleyball);
        }

        private void TugOfWar_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(tugOfWar);
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy zapisać stan programu?", "Wyjście", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

            }
            mainWindow.Close();
        }

        public static void load(string? fname, Volleyball volleyball, Tug_of_war tugOfWar)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra i czy taki plik istnieje
            if (fname == null || fname.Length == 0 || !File.Exists($@"..\..\..\saved\{fname}.txt"))
            {
                Console.WriteLine("Niepoprawna nazwa pliku");
                return;
            }

            //Usuwamy to co było wcześniej w listach
            volleyball.clearTeams();
            volleyball.clearJudges();
            tugOfWar.clearTeams();
            tugOfWar.clearJudges();

            //Póki co tylko dla siatkówki, sprawdzamy czy dana linijka to drużyna czy sędzia, potem jaki sport, i dodajemy do odpowiedniej listy
            StreamReader loadStream = new StreamReader($@"..\..\..\saved\{fname}.txt");
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
                        volleyball.addJudge(new Judge(dane[2], dane[3]));
                    }
                    else if (dane[1].Equals("T"))
                    {
                        tugOfWar.addJudge(new Judge(dane[2], dane[3]));
                    }
                }
            }
            loadStream.Close();
        }
        public static void save(string? fname, Volleyball volleyball, Tug_of_war tugOfWar)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra
            if (fname == null || fname.Length == 0)
            {
                Console.WriteLine("Niepoprawna nazwa pliku");
                return;
            }

            //Zapisujemy w kodzie T,[sport],[nazwa] dla drużyn i J,[sport],[imie],[nazwisko] dla sędziów
            StreamWriter saveStream = new StreamWriter($@"..\..\..\saved\{fname}.txt");
            volleyball.getTeams().ForEach(team =>
            {
                saveStream.WriteLine($"T,V,{team.getName()}");
            });
            volleyball.getJudges().ForEach(judge =>
            {
                saveStream.WriteLine($"J,V,{judge.getName()},{judge.getSurname()}");
            });
            tugOfWar.getTeams().ForEach(team =>
            {
                saveStream.WriteLine($"T,T.{team.getName()}");
            });
            tugOfWar.getJudges().ForEach(judge =>
            {
                saveStream.WriteLine($"J,T,{judge.getName()}, {judge.getSurname()}");
            });
            saveStream.Close();
        }
    }
}
