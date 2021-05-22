﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    public class VesselStorage: IVessel
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
            if (vessels.Count != 0)
            {
                //this.vessels.RemoveAt(0);
                Random rand = new Random();
                int vesselNumber = rand.Next(this.vessels.Count - 1);
                Vessel vessel = vessels.ElementAt(vesselNumber);
                //this.vessels.Remove(vessel);
                return vessel;
            }
            return null;
        }

        public void deleteVesselById(int id)
        {
            for (int i = 0; i < this.vessels.Count; i++)
            {
                Vessel vessel = this.vessels.ElementAt(i);
                if (vessel.getId() == id)
                    this.vessels.Remove(vessel);
            }
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
