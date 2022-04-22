using System;

namespace Projekt
{
    public class Projekt
    {
        public static void Main()
        {
            Volleyball volleyball = new Volleyball();

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
                        Console.WriteLine("Dodane 10 drużyn");
                        break;
                    case 3:
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
