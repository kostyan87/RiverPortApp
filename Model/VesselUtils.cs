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

        public static int generateDeviation(int shipsTime)
        {
            Random rand = new Random();
            int sign = rand.Next(2);
            int deviation;

            if (sign == 0)
                deviation = rand.Next((shipsTime / 2));
            else
                deviation = -rand.Next((shipsTime / 2));

            return deviation;
        }
    }
}
