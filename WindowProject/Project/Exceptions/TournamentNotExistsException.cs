namespace Project.Exceptions
{
    public class TournamentNotExistsException : TournamentException
    {
        public TournamentNotExistsException(string name, string category) : base(name, category) { }
    }
}
