using System;

namespace Coeus.Models
{
    class CoeusException : Exception
    {
        public CoeusException(string message) : base(message) { }
        public CoeusException(string message, Exception inner) : base(message, inner) { }
    }
}
