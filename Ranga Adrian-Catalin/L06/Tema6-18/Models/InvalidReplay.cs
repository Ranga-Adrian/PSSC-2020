using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6_18.Models
{
    [Serializable]
    public class InvalidReplay : Exception
    {
        public InvalidReplay()
        {
        }

        public InvalidReplay(string replay) : base($"Your answer ( \"{replay}\") is not between 10-500 characters.")
        {
        }
    }
}
