using RiverPortApp.View;
using RiverPortApp.Model;

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
            view.showVesselStorage(facade.getProcessingComponents().
                                          getVesselStorage().getStringVessels());
        }

        public void loadTime()
        {
            view.showTime(facade.getTimeManager().getMin(),
                          facade.getTimeManager().getHour(),
                          facade.getTimeManager().getDay());
        }

        public void changeTime()
        {
            facade.getTimeManager().increaseTime();
        }
    }
}
