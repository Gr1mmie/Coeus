namespace Coeus.Models { 
    public abstract class Util
    {
        public abstract string UtilName { get; }
        public abstract string UtilDesc { get;  }
        public abstract string UtilExec(string[] args); 
    }
}
