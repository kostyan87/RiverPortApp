using RiverPortApp.View;
using RiverPortApp.Model;
using System.Collections.Generic;

namespace RiverPortApp.Presenter
{
    class MainPresenter
    {
        private IMainView view;

        private Facade facade;

        public MainPresenter(IMainView view)
        {
            this.view = view;
        }

        // Метод для инициализации фасада
        public void initFacade(int smallShipsCount, int mediumShipsCount,
                               int largeShipsCount, int smallShipsServiceTime,
                               int mediumShipsServiceTime, int largeShipsServiceTime,
                               int shipsTime)
        {
            facade = new Facade(smallShipsCount, mediumShipsCount,
                                largeShipsCount, smallShipsServiceTime,
                                mediumShipsServiceTime, largeShipsServiceTime,
                                shipsTime);
        }

        // Метод для загрузки хранилища судов в форму (используется только для тестов)
        public void loadVesselStorage()
        {
            view.addVesselsToStorage(facade.getProcessingComponents().
                                          getVesselStorage());
        }

        public void loadTime()
        {
            view.showTime(facade.getTimeManager().getMin(),
                          facade.getTimeManager().getHour(),
                          facade.getTimeManager().getDay(),
                          facade.getTimeManager().getGeneralHour());
        }

        public void loadVesselToRoadstead()
        {
            if (facade.getShipOutOfStorage() != null)
            {
                Vessel vessel = facade.getShipOutOfStorage();
                facade.getProcessingComponents().getPort().getRoadstead().pushVessel(vessel);
                view.addVesselToRoadstead(vessel);
                view.removeVesselFromStorage(vessel);
                facade.getProcessingComponents().getVesselStorage().deleteVesselById(vessel.getId());
            }
        }

        public void changeTime()
        {
            facade.getTimeManager().increaseTime();
        }

        public void loadVesselToPiers()
        {
            Port port = facade.getProcessingComponents().getPort();
            int id = facade.addShipToPier();
            if (id != -1)
            {
                view.removeVesselFromRoadstead(id);
            }
            view.addVesselsToPiers(port);
        }

        public void removeVesselFromPier()
        {
            List<Pier> piers = facade.getProcessingComponents().getPort().getPiers();

            for (int i = 0; i < piers.Count; i++)
            {
                if (!piers[i].isFree)
                {
                    int time = piers[i].getCurrentServiceShip().getServiceTime()
                           + piers[i].getCurrentServiceShip().getPierCallTime();
                    int currentTime = facade.getTimeManager().getGeneralHour();
                    if (time == currentTime)
                    {
                        piers[i].isFree = true;
                        view.cleanPier(i);
                        piers[i].increaseNumberOfShipsServ();
                        piers[i].increaseNumberOfSmallShipsServ(piers[i].getCurrentServiceShip().getSize());
                        piers[i].increaseNumberOfMedShipsServ(piers[i].getCurrentServiceShip().getSize());
                        piers[i].increaseNumberOfLargeShipsServ(piers[i].getCurrentServiceShip().getSize());
                    }
                }
            }
        }
    }
}
