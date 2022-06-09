using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class Volleyball : Tournament
    {
        public Volleyball(string name, Random random) : base(name, random) { }

        public override string getCategory()
        {
            return "Siatkówka";
        }
        public override string getBackground()
        {
            return "/Backgrounds/volleyball.png";
        }
        public override void playRandom()
        {
            foreach (Game game in games)
            {
                if (game.getWinner() is null)
                {
                    game.playRandom();
                    game.setJudges(judges[random.Next(judges.Count)], judges[random.Next(judges.Count)], judges[random.Next(judges.Count)]);
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Volleyball)) return false;
            Volleyball vTeam = (Volleyball)obj;
            return name.Equals(vTeam.name);
        }
    }
}
