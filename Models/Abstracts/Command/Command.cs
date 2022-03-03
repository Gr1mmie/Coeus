namespace Coeus.Models
{
    public abstract class Command
    {
        public abstract string CommandName { get; }
        public abstract string CommandDesc { get; }
        public abstract string CommandUsage { get; }
        public abstract string CommandExec(string[] args);
    }
}
