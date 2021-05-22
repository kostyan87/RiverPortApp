using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    public class Port
    {
        private List<Pier> piers;

        private Roadstead roadstead;

        public Port()
        {
            this.setPiers();
            this.roadstead = new Roadstead();
        }

        public void setPiers()
        {
            piers = new List<Pier>();

            for (int i = 0; i < 4; i++)
            {
                piers.Add(new Pier());
            }
        }

        public int willBeEnoughPiers(int shipSize)
        {
            int maxFreePiersCount = 0;
            int freePiersCount = 0;
            int startIndex = -1;

            for(int i = 0; i < 4; i++)
            {
                if (piers[i].isFree)
                {
                    if (freePiersCount == 0)
                    {
                        startIndex = i;
                    }
                    freePiersCount++;
                }   
                else
                {
                    if (freePiersCount > maxFreePiersCount)
                    {
                        maxFreePiersCount = freePiersCount;
                    }
                    freePiersCount = 0;
                }
            }

            if (maxFreePiersCount != shipSize)
            {
                startIndex = -1;
            }

            return startIndex;
        }

        public void takePiers(Vessel vessel, int startIndex)
        {
            for (int i = startIndex; i <= vessel.getSize(); i++)
            {
                piers[i].setCurrentServiceShip(vessel);
            }
        }

        public Roadstead getRoadstead()
        {
            return this.roadstead;
        }

        public List<Pier> getPiers()
        {
            return this.piers;
        }
    }
}
