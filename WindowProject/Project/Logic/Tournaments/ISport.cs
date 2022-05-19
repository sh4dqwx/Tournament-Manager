using System;

namespace Project.Logic.Tournaments
{
    public interface ISport
    {
        public void generateElimination();
        public void generateSemiFinal();
        public void generateFinal();
    }
}
