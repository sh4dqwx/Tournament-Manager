using System;
using System.Collections.Generic;
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
        public override void playRandom()
        {
            foreach (Game game in games)
            {
                if (game.getWinner() is null)
                {
                    game.playRandom();
                    List<Judge> judgesToChoose = new List<Judge>(judges);
                    List<Judge> judgesToSend = new List<Judge>();
                    for(int i=0; i<3; i++)
                    {
                        int k = random.Next(judgesToChoose.Count);
                        judgesToSend.Add(judgesToChoose[k]);
                        judgesToChoose.Remove(judgesToChoose[k]);
                    }
                    game.setJudges(judgesToSend[0], judgesToSend[1], judgesToSend[2]);
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
