namespace Project.Exceptions
{
    public class TeamNotExistsException : TeamException
    {
        public TeamNotExistsException(string name) : base(name) { }
    }
}
