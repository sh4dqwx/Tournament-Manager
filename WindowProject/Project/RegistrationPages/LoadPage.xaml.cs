using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Project.Games;
using Project.Registrations;

namespace Project.RegistrationPages
{
    /// <summary>
    /// Logika interakcji dla klasy LoadPage.xaml
    /// </summary>
    public partial class LoadPage : Page
    {
        private MenuPage _menu;
        public LoadPage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        public static void load(string? fileName, Volleyball volleyball, Tug_of_war tugOfWar)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra i czy taki plik istnieje
            if (fileName == null || fileName.Length == 0 || !File.Exists($@"..\..\..\saved\{fileName}.txt"))
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
            StreamReader loadStream = new StreamReader($@"..\..\..\saved\{fileName}.txt");
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

        private void Load_Button(object sender, RoutedEventArgs e)
        {
            load(fileName.Text, _menu.volleyball, _menu.tug_Of_War);
        }
        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }
    }
}
