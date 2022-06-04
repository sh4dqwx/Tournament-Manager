using System;
using System.Collections.Generic;

namespace Project.Logic.Registrations
{
    public class Game
    {
        private Team firstTeam, secondTeam, winner, loser;
        private Random random;

        public Game(Team firstTeam, Team secondTeam, Random random)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.random = random;
        }

        public Team getFirstTeam()
        {
            return firstTeam;
        }
        public Team getSecondTeam()
        {
            return secondTeam;
        }
        public Team getWinner()
        {
            return winner;
        }
        public Team getLoser()
        {
            return loser;
        }

        public void playManual(int chosen)
        {
            if (chosen == 1)
            {
                winner = firstTeam;
                loser = secondTeam;
                firstTeam.addScore(true);
                secondTeam.addScore(false);
            }
            else if (chosen == 2)
            {
                winner = secondTeam;
                loser = firstTeam;
                firstTeam.addScore(false);
                secondTeam.addScore(true);
            }
            else throw new Exception("Wrong number");
        }

        public void playRandom()
        {
            if (random.NextDouble() >= 0.5)
            {
                winner = firstTeam;
                loser = secondTeam;
                firstTeam.addScore(true);
                secondTeam.addScore(false);
            }
            else
            {
                winner = secondTeam;
                loser = firstTeam;
                firstTeam.addScore(false);
                secondTeam.addScore(true);
            }
        }
    }
}
