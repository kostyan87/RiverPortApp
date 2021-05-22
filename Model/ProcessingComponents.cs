using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp.Model
{
    class ProcessingComponents
    {
        private VesselStorage vesselStorage;

        private Port port;

        public ProcessingComponents(int smallShipsCount, int mediumShipsCount,
                                    int largeShipsCount, int smallShipsServiceTime,
                                    int mediumShipsServiceTime, int largeShipsServiceTime,
                                    int shipsTime)
        {
            this.vesselStorage = new VesselStorage(smallShipsCount,
                                                   mediumShipsCount,
                                                   largeShipsCount,
                                                   smallShipsServiceTime,
                                                   mediumShipsServiceTime,
                                                   largeShipsServiceTime,
                                                   shipsTime);
            this.port = new Port();
        }

        public VesselStorage getVesselStorage()
        {
            return this.vesselStorage;
        }

        public Port getPort()
        {
            return this.port;
        }
    }
}
