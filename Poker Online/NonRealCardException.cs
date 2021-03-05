using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Online
{
    class NonRealCardException : Exception
    {
        public NonRealCardException()
        {
        }

        public NonRealCardException(string message)
            : base(message) { }

        public NonRealCardException(string message, Exception inner)
            : base(message, inner) { }
    }
}
