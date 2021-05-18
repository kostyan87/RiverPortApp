using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class Controller
    {
        private VesselStorage vesselStorage;

        private Roadstead roadstead;

        private Port port;

        public Controller(int smallShipsCount,
                          int mediumShipsCount,
                          int largeShipsCount,
                          int smallShipsServiceTime,
                          int mediumShipsServiceTime,
                          int largeShipsServiceTime,
                          int shipsTime)
        {
            this.vesselStorage = new VesselStorage(smallShipsCount,
                                                   mediumShipsCount,
                                                   largeShipsCount,
                                                   smallShipsServiceTime,
                                                   mediumShipsServiceTime,
                                                   largeShipsServiceTime);
        }

        public VesselStorage getVesselStorage()
        {
            return vesselStorage;
        }
    }
}
