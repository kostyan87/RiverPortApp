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

        private double smallVesselMiddleTime;

        private double medVesselMiddleTime;

        private double largeVesselMiddleTime;

        public Facade(int smallShipsCount, int mediumShipsCount,
                      int largeShipsCount, int smallShipsServiceTime,
                      int mediumShipsServiceTime, int largeShipsServiceTime,
                      int shipsTime)
        {
            this.timeManager = new TimeManager(shipsTime);
            this.processingComponents = new ProcessingComponents(smallShipsCount, mediumShipsCount,
                                                                 largeShipsCount, smallShipsServiceTime,
                                                                 mediumShipsServiceTime, largeShipsServiceTime,
                                                                 shipsTime);
        }

        public void calculateAverageTime(int smallShipsCount, int mediumShipsCount,
                                         int largeShipsCount)
        {
            smallVesselMiddleTime = smallVesselMiddleTime / smallShipsCount;
            medVesselMiddleTime = medVesselMiddleTime / mediumShipsCount;
            largeVesselMiddleTime = largeVesselMiddleTime / largeShipsCount;
        }

        public double getSmallVesselMiddleTime()
        {
            return this.smallVesselMiddleTime;
        }

        public double getMedVesselMiddleTime()
        {
            return this.medVesselMiddleTime;
        }

        public double getLargeVesselMiddleTime()
        {
            return this.largeVesselMiddleTime;
        }

        public void setVesselMiddleTime(Vessel vessel, int time)
        {
            if (vessel.getSize() == 1)
            {
                this.smallVesselMiddleTime = time;
            }

            if (vessel.getSize() == 1)
            {
                this.medVesselMiddleTime = time;
            }

            if (vessel.getSize() == 1)
            {
                this.largeVesselMiddleTime = time;
            }
        }

        public ProcessingComponents getProcessingComponents()
        {
            return processingComponents;
        }

        public TimeManager getTimeManager()
        {
            return timeManager;
        }

        public Vessel getShipOutOfStorage()
        {
            Vessel vessel = this.processingComponents.getVesselStorage().getVessel();
            if (vessel != null)
            {
                if (this.timeManager.getGeneralHour() % vessel.getShipsTime() == 0
                && this.timeManager.getMin() == 0)
                {
                    return vessel;
                }
            }
            return null;
        }

        public int addShipToPier()
        {
            if (!this.processingComponents.getPort().getRoadstead().isEmpty())
            {
                Port port = this.processingComponents.getPort();
                Roadstead roadstead = port.getRoadstead();
                Vessel vessel = roadstead.getPeekVessel();
                int startIndex = port.willBeEnoughPiers(vessel.getSize());

                if (startIndex != -1)
                {
                    int id = roadstead.getPeekVessel().getId();
                    port.takePiers(vessel, startIndex);
                    vessel.setPierCallTime(this.timeManager.getGeneralHour());
                    this.setVesselMiddleTime(vessel, vessel.getPierCallTime()
                                                    - vessel.getTimeArrivalRoadstead());
                    roadstead.popVessel();
                    return id;
                }
            }
            return -1;
        }
    }
}
