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

        public override bool Equals(object obj)
        {
            if (!(obj is Volleyball)) return false;
            Volleyball vTeam = (Volleyball)obj;
            return name.Equals(vTeam.name);
        }
    }
}
