using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class VesselStorageUtils
    {
        public static List<Vessel> setVessels(int smallShipsCount,
                                              int mediumShipsCount,
                                              int largeShipsCount,
                                              int smallShipsServiceTime,
                                              int mediumShipsServiceTime,
                                              int largeShipsServiceTime)
        {
            List<Vessel> vessels = new List<Vessel>();
            List<string> idList = new List<string>();

            for (int i = 0; i < smallShipsCount; i++)
            {
                Vessel smallShip = new Vessel(generateId(idList), 1, smallShipsServiceTime);
                vessels.Add(smallShip);
            }

            for (int i = 0; i < mediumShipsCount; i++)
            {
                Vessel medShip = new Vessel(generateId(idList), 2, mediumShipsServiceTime);
                vessels.Add(medShip);
            }

            for (int i = 0; i < largeShipsCount; i++)
            {
                Vessel largeShip = new Vessel(generateId(idList), 3, largeShipsServiceTime);
                vessels.Add(largeShip);
            }

            return vessels;
        }

        public static int generateId(List<string> idList)
        {
            Random randDigit = new Random();
            string id = "";

            for (int i = 0; i < 5; i++)
            {
                id = id + randDigit.Next(1, 10);
            }

            if (idList.Contains(id))
            {
                generateId(idList);
            }

            idList.Add(id);

            return Convert.ToInt32(id);
        }
    }
}
