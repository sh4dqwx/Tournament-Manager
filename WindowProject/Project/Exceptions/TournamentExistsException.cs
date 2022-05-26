namespace Project.Exceptions
{
    public class TournamentExistsException : TournamentException
    {
        public TournamentExistsException(string name, string category): base(name, category) { }
    }
}
