using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp.Model
{
    class TimeManager
    {
        private int day = 0;

        private int hour = 0;

        private int min = 0;

        private int shipsTime;

        public TimeManager(int shipsTime)
        {
            setShipsTime(shipsTime);
        }

        public void increaseTime()
        {
            this.min++;

            if (this.min == 60)
            {
                this.min = 0;
                this.hour++;
            }

            if (this.hour == 24)
            {
                this.hour = 0;
                this.day++;
            }
        }

        public void setShipsTime(int shipsTime)
        {
            if (shipsTime >= 0) this.shipsTime = shipsTime;
            else throw new IncorrectDataException("Некорректные данные");
        }

        public int getMin()
        {
            return this.min;
        }

        public int getHour()
        {
            return this.hour;
        }

        public int getDay()
        {
            return this.day;
        }
    }
}
