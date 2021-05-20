using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class VesselUtils
    {
        public static int generateId()
        {
            Random randDigit = new Random();
            string id = "";

            for (int i = 0; i < 5; i++)
            {
                id = id + randDigit.Next(10);
            }

            return Convert.ToInt32(id);
        }
    }
}
