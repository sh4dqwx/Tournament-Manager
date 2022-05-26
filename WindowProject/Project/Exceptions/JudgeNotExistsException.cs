namespace Project.Exceptions
{
    public class JudgeNotExistsException : JudgeException
    {
        public JudgeNotExistsException(string name, string surname) : base(name, surname) { }
    }
}
