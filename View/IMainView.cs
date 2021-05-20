using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverPortApp.View
{
    interface IMainView
    {
        void showVesselStorage(string vesselStorage);

        void showTime(int min, int hour, int day);
    }
}
