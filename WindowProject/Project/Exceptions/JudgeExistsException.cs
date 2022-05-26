namespace Project.Exceptions
{
    public class JudgeExistsException : JudgeException
    {
        public JudgeExistsException(string name, string surname): base(name, surname) { }
    }
}
