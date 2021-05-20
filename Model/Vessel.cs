using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class Vessel
    {
        private long id;

        private int size;

        private int serviceTime;

        private int timeInRoadstead = 0;

        public Vessel(int id, int size, int serviceTime)
        {
            this.id = id;
            this.size = size;
            this.serviceTime = serviceTime;
        }

        public int getSize() { return this.size; }

        public int getServiceTime() { return this.serviceTime; }

        public long getId() { return this.id; }

        public void setSize(int size) { this.size = size; }
    }
}
