using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class TugOfWar : Tournament
    {
        public TugOfWar(string name, Random random) : base(name, random) { }

        public override string getCategory()
        {
            return "Przeciąganie liny";
        }
        public override string getBackground()
        {
            return "/Backgrounds/tug_of_war.png";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TugOfWar)) return false;
            TugOfWar tTeam = (TugOfWar)obj;
            return name.Equals(tTeam.name);
        }
    }
}
