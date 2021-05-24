using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    public class Vessel
    {
        private int id;

        private int size;

        private int serviceTime;

        private int standartShipsTime;

        private int shipsTime;

        private int timeArrivalRoadstead;

        private int pierCallTime;

        public Vessel(int id, int size, int serviceTime, int shipsTime)
        {
            this.id = id;
            this.size = size;
            this.serviceTime = serviceTime;
            this.serviceTime = this.serviceTime + VesselUtils.generateDeviation(this.serviceTime);
            this.shipsTime = shipsTime;
            this.standartShipsTime = shipsTime;
        }

        public int getTimeArrivalRoadstead() { return this.timeArrivalRoadstead; }

        public int getSize() { return this.size; }

        public int getServiceTime() { return this.serviceTime; }

        public int getId() { return this.id; }

        public int getShipsTime()
        {
            return this.shipsTime;
        }

        public int getPierCallTime()
        {
            return this.pierCallTime;
        }

        public void setSize(int size) { this.size = size; }

        public void setShipsTime(int k)
        {
            this.shipsTime = this.shipsTime * k + VesselUtils.generateDeviation(this.standartShipsTime);
        }

        public void setPierCallTime(int hour)
        {
            this.pierCallTime = hour;
        }

        public void setTimeArrivalRoadstead(int hour)
        {
            this.timeArrivalRoadstead = hour;
        }
    }
}
