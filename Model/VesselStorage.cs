using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class VesselStorage: IVessel
    {
        private List<Vessel> vessels;

        public VesselStorage(int smallShipsCount,
                             int mediumShipsCount,
                             int largeShipsCount,
                             int smallShipsServiceTime,
                             int mediumShipsServiceTime,
                             int largeShipsServiceTime)
        {
            this.vessels = VesselStorageUtils.setVessels(smallShipsCount,
                                                         mediumShipsCount,
                                                         largeShipsCount,
                                                         smallShipsServiceTime,
                                                         mediumShipsServiceTime,
                                                         largeShipsServiceTime);
        }

        public Vessel getVessel()
        {
            Random rand = new Random();
            int vesselNumber = rand.Next(this.vessels.Count - 1);
            Vessel vessel = vessels.ElementAt(vesselNumber);
            this.vessels.RemoveAt(vesselNumber);

            return vessel;
        }

        public string getStringVessels()
        {
            string s = "";

            for (int i = 0; i < vessels.Count; i++)
            {
                s = s + vessels.ElementAt(i).getId().ToString() + " " +
                    vessels.ElementAt(i).getSize().ToString() + " " +
                    vessels.ElementAt(i).getServiceTime().ToString() + "\n";
            }

            return s;
        }

        public List<Vessel> getVessels()
        {
            return vessels;
        }
    }
}
