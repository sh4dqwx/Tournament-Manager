using System;

namespace Projekt
{
    public class Projekt
    {
        private static void save(string fname, Volleyball volleyball)
        {
            /**
             * Zapisywanie do pliku:
             * - Podaj nazwe pliku, do ktorego ma zapisac
             * - Dla każdego sportu podanego jako parametr metody zapisz do pliku wszystkich sędziów i drużyny w specjalnym kodzie
             * - Drużyna: TVDrużyna10 (typ (T), typ sportu (V - volleyball) nazwa drużyny(Drużyna 1), aktualny wynik drużyny(0))
             * - Sędzia: JVJanKowalski (typ (J), typ sportu (V - volleyball) imię sędziego(Jan), nazwisko sędziego(Kowalski))
             */
            StreamWriter saveStream = new StreamWriter($@"saved\{fname}.txt");
            volleyball.getTeams().ForEach(team =>
            {
                saveStream.WriteLine($"T,V,{team.getName()},{team.getScore()}");
            });
            saveStream.Close();
        }
        public static void Main()
        {
            Volleyball volleyball = new Volleyball();
            string dirpath = Directory.GetCurrentDirectory();
            Console.WriteLine(dirpath);

            int wybor = -1;
            bool end = false;
            while(end == false)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Wczytaj z pliku");
                Console.WriteLine("2. Domyślne");
                Console.WriteLine("3. Zapisz do pliku");
                Console.WriteLine("4. Zagraj");
                Console.WriteLine("0. Zakończ działanie programu");
                Console.WriteLine("------------------------------");
                wybor = Convert.ToInt16(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        break;
                    case 2:
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
                        volleyball.addJudge(new Judge("Sędzia", "1", "volleyball"));
                        volleyball.addJudge(new Judge("Sędzia", "2", "volleyball"));
                        volleyball.addJudge(new Judge("Sędzia", "3", "volleyball"));
                        volleyball.addJudge(new Judge("Sędzia", "4", "volleyball"));
                        volleyball.addJudge(new Judge("Sędzia", "5", "volleyball"));
                        Console.WriteLine("Dodane 10 drużyn i 5 sędziów");
                        break;
                    case 3:
                        Console.Write("Nazwa pliku: ");
                        string? fname = Console.ReadLine();
                        if(fname == null || fname.Length == 0)
                        {
                            Console.WriteLine("Niepoprawna nazwa pliku");
                        } 
                        else save(fname, volleyball);
                        break;
                    case 4:
                        volleyball.playElimination();
                        break;
                    case 0:
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
