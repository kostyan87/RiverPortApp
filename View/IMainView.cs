using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverPortApp.Model;
    
namespace RiverPortApp.View
{
    interface IMainView
    {
        //void showVesselStorage(string vesselStorage);

        void showTime(int min, int hour, int day, int generalHour);

        void addVesselToRoadstead(Vessel vessel);

        void removeVesselFromStorage(Vessel vessel);

        void addVesselsToStorage(VesselStorage storage);

        void addVesselsToPiers(Port port);

        void removeVesselFromRoadstead(int id);

        void cleanPier(int pierNumber);

        void stopTime();

        void changePierData(Port port, int numberOfPier);

        void showMiddleAverage(double smallVesselMiddleTime,
                               double medVesselMiddleTime,
                               double largeVesselMiddleTime);
    }
}
