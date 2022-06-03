﻿using System;
using System.Collections.Generic;

namespace Project.Logic.Registrations
{
    public class Game
    {
        private Team firstTeam, secondTeam, winner;
        private Random random = new Random();

        public Game(Team firstTeam, Team secondTeam)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
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

        public void playManual(int chosen)
        {
            if (chosen == 1)
            {
                winner = firstTeam;
                firstTeam.addScore(true);
                secondTeam.addScore(false);
            }
            else if (chosen == 2)
            {
                winner = secondTeam;
                firstTeam.addScore(false);
                secondTeam.addScore(true);
            }
            else throw new Exception("Wrong number");
        }

        public Team playRandom()
        {
            if (random.NextDouble() >= 0.5) winner = firstTeam;
            else winner = secondTeam;
            return winner;
        }
    }
}
