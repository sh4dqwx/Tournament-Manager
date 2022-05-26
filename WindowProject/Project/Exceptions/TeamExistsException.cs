namespace Project.Exceptions
{
    public class TeamExistsException : TeamException
    {
        public TeamExistsException(string name): base(name) { }
    }
}
