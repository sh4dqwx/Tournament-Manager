using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class TugOfWar : Tournament
    {
        public TugOfWar(string name) : base(name) { }

        public override string getCategory()
        {
            return "Przeciąganie liny";
        }

        public void generateFinal()
        {
            games.Add(new Game(teams[0], teams[1]));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TugOfWar)) return false;
            TugOfWar tTeam = (TugOfWar)obj;
            return name.Equals(tTeam.name);
        }
    }
}
