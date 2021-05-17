using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp
{
    class Pier
    {
        private int currentServiceShip;

        private int numberOfShipsServ;

        private int numberOfSmallShipsServ;

        private int numberOfMedShipsServ;

        private int numberOfLargeShipsServ;

        private int getCurrentServiceShip()
        {
            return this.currentServiceShip;
        }

        private bool isFree()
        {
            return false;
        }

        private int getNumberOfShipsServ()
        {
            return this.numberOfShipsServ;
        }

        private int getNumberOfSmallShipsServ()
        {
            return this.numberOfSmallShipsServ;
        }

        private int getNumberOfMedShipsServ()
        {
            return this.numberOfMedShipsServ;
        }

        private int getNumberOfLargeShipsServ()
        {
            return this.numberOfLargeShipsServ;
        }
    }
}
