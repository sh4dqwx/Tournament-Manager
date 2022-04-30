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

        private void Load_Button(object sender, RoutedEventArgs e)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra i czy taki plik istnieje
            if (fileName.Text == null || fileName.Text.Length == 0 || !File.Exists($@"..\..\..\saved\{fileName.Text}.txt"))
            {
                messageText.Text = "Niepoprawna nazwa pliku";
                fileName.Text = "";
                return;
            }

            //Usuwamy to co było wcześniej w listach
            _menu.volleyball.clearTeams();
            _menu.volleyball.clearJudges();
            _menu.tugOfWar.clearTeams();
            _menu.tugOfWar.clearJudges();

            //Póki co tylko dla siatkówki, sprawdzamy czy dana linijka to drużyna czy sędzia, potem jaki sport, i dodajemy do odpowiedniej listy
            StreamReader loadStream = new StreamReader($@"..\..\..\saved\{fileName.Text}.txt");
            while (!loadStream.EndOfStream)
            {
                string[] dane = loadStream.ReadLine().Split(',');
                if (dane[0].Equals("T"))
                {
                    if (dane[1].Equals("V"))
                    {
                        _menu.volleyball.addTeam(new Team(dane[2]));
                    }
                    else if (dane[1].Equals("T"))
                    {
                        _menu.tugOfWar.addTeam(new Team(dane[2]));
                    }
                }
                else if (dane[0].Equals("J"))
                {
                    if (dane[1].Equals("V"))
                    {
                        _menu.volleyball.addJudge(new Judge(dane[2], dane[3]));
                    }
                    else if (dane[1].Equals("T"))
                    {
                        _menu.tugOfWar.addJudge(new Judge(dane[2], dane[3]));
                    }
                }
            }
            loadStream.Close();
            messageText.Text = "Wczytano";
            fileName.Text = "";
        }
        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            fileName.Text = "";
            messageText.Text = "";
            NavigationService.Navigate(_menu);
        }
    }
}
