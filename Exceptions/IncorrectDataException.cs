using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class IncorrectDataException : Exception
    {
        public IncorrectDataException(string message) : base(message)
        {
        }
    }
}
