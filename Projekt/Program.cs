using System;

namespace Projekt
{
    public class Projekt
    {
        public static void load(string? fname, Volleyball volleyball)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra i czy taki plik istnieje
            if (fname == null || fname.Length == 0 || !File.Exists($@"saved\{fname}.txt"))
            {
                Console.WriteLine("Niepoprawna nazwa pliku");
                return;
            }

            //Usuwamy to co było wcześniej w listach
            volleyball.clearTeams();
            volleyball.clearJudges(); 

            //Póki co tylko dla siatkówki, sprawdzamy czy dana linijka to drużyna czy sędzia, potem jaki sport, i dodajemy do odpowiedniej listy
            StreamReader loadStream = new StreamReader($@"saved\{fname}.txt");
            while(!loadStream.EndOfStream)
            {
                string[] dane = loadStream.ReadLine().Split(',');
                if(dane[0].Equals("T"))
                {
                    if(dane[1].Equals("V"))
                    {
                        volleyball.addTeam(new Team(dane[2]));
                    }
                }
                else if(dane[0].Equals("J"))
                {
                    if (dane[1].Equals("V"))
                    {
                        volleyball.addJudge(new Judge(dane[2], dane[3]));
                    }
                }
            }
            loadStream.Close();
        }
        public static void save(string? fname, Volleyball volleyball)
        {
            //Najpierw sprawdzamy czy nazwa pliku jest dobra
            if (fname == null || fname.Length == 0)
            {
                Console.WriteLine("Niepoprawna nazwa pliku");
                return;
            }

            //Zapisujemy w kodzie T,[sport],[nazwa] dla drużyn i J,[sport],[imie],[nazwisko] dla sędziów
            StreamWriter saveStream = new StreamWriter($@"saved\{fname}.txt");
            volleyball.getTeams().ForEach(team =>
            {
                saveStream.WriteLine($"T,V,{team.getName()}");
            });
            volleyball.getJudges().ForEach(judge =>
            {
                saveStream.WriteLine($"J,V,{judge.getName()},{judge.getSurname()}");
            });
            saveStream.Close();
        }
        public static void Main()
        {
            
            Volleyball volleyball = new Volleyball();
            
            //Rozbudowany main, dodałem proste menu tekstowe, żeby łatwiej mi się testowało
            int wybor = -1;
            bool end = false;
            string? fname = "";
            while(end == false)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Wczytaj z pliku");
                Console.WriteLine("2. Domyślne");
                Console.WriteLine("3. Zapisz do pliku");
                Console.WriteLine("4. Przegląd drużyn");
                Console.WriteLine("5. Zagraj");
                Console.WriteLine("0. Zakończ działanie programu");
                Console.WriteLine("------------------------------");
                wybor = Convert.ToInt16(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        //Bierze nazwę pliku i wczytuje z niego dane
                        Console.Write("Nazwa pliku: ");
                        fname = Console.ReadLine();                        
                        load(fname, volleyball);
                        break;
                    case 2:
                        //Dodaje 10 drużyn i 5 sędziów
                        volleyball.addTeam(new Team("Drużyna 1"));
                        volleyball.addTeam(new Team("Drużyna 2"));
                        volleyball.addTeam(new Team("Drużyna 3"));
                        volleyball.addTeam(new Team("Drużyna 4"));
                        volleyball.addTeam(new Team("Drużyna 5"));
                        volleyball.addTeam(new Team("Drużyna 6"));
                        volleyball.addTeam(new Team("Drużyna 7"));
                        volleyball.addTeam(new Team("Drużyna 8"));
                        volleyball.addTeam(new Team("Drużyna 9"));
                        volleyball.addTeam(new Team("Drużyna 10"));
                        volleyball.addJudge(new Judge("Sędzia", "1"));
                        volleyball.addJudge(new Judge("Sędzia", "2"));
                        volleyball.addJudge(new Judge("Sędzia", "3"));
                        volleyball.addJudge(new Judge("Sędzia", "4"));
                        volleyball.addJudge(new Judge("Sędzia", "5"));
                        Console.WriteLine("Dodane 10 drużyn i 5 sędziów");
                        break;
                    case 3:
                        //Bierze nazwę pliku i zapisuje dane do pliku pod tą nazwą
                        Console.Write("Nazwa pliku: ");
                        fname = Console.ReadLine();                        
                        save(fname, volleyball);
                        break;
                    case 4:
                        //Wypisuje nazwy wszystkich drużyn które obecnie istnieją
                        if (volleyball.getTeams().Count() == 0) Console.WriteLine("Brak drużyn");
                        else volleyball.getTeams().ForEach(team => { Console.WriteLine(team.getName()); });
                        break;
                    case 5:
                        //Gramy B)
                        volleyball.playElimination();
                        break;
                    case 0:
                        //Kończy program
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Zła komenda, spróbuj ponownie");
                        break;
                }
            }
            
            /*List<Team> teams = volleyball.getTeams();
            teams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore().ToString()));*/
        }
    }
}
