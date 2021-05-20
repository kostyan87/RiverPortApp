using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp.Model
{
    class Facade
    {
        private TimeManager timeManager;

        private ProcessingComponents processingComponents;

        public Facade(int smallShipsCount, int mediumShipsCount,
                      int largeShipsCount, int smallShipsServiceTime,
                      int mediumShipsServiceTime, int largeShipsServiceTime,
                      int shipsTime)
        {
            this.timeManager = new TimeManager(shipsTime);
            this.processingComponents = new ProcessingComponents(smallShipsCount, mediumShipsCount,
                                                                 largeShipsCount, smallShipsServiceTime,
                                                                 mediumShipsServiceTime, largeShipsServiceTime);
        }

        public ProcessingComponents getProcessingComponents()
        {
            return processingComponents;
        }

        public TimeManager getTimeManager()
        {
            return timeManager;
        }
    }
}
