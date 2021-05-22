using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    public class Pier
    {
        private Vessel currentServiceShip;

        private int numberOfShipsServ = 0;

        private int numberOfSmallShipsServ = 0;

        private int numberOfMedShipsServ = 0;

        private int numberOfLargeShipsServ = 0;

        public bool isFree = true;

        public Vessel getCurrentServiceShip()
        {
            return this.currentServiceShip;
        }

        public void setCurrentServiceShip(Vessel vessel)
        {
            isFree = false;
            this.currentServiceShip = vessel;
        }

        public int getNumberOfShipsServ()
        {
            return this.numberOfShipsServ;
        }

        public int getNumberOfSmallShipsServ()
        {
            return this.numberOfSmallShipsServ;
        }

        public int getNumberOfMedShipsServ()
        {
            return this.numberOfMedShipsServ;
        }

        public int getNumberOfLargeShipsServ()
        {
            return this.numberOfLargeShipsServ;
        }
    }
}
