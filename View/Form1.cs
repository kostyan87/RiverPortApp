using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using RiverPortApp.Presenter;
using RiverPortApp.Model;

namespace RiverPortApp.View
{
    public partial class Form1 : Form, IMainView
    {
        private MainPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
        }

        // Загружает судна во вкладку "Обслуживаемые суда"
        public void addVesselsToStorage(VesselStorage storage)
        {
            foreach (Vessel vessel in storage.getVessels())
            {
                if (vessel.getSize() == 1)
                {
                    storageSmallShips.Rows.Add(vessel.getId(),
                                               vessel.getSize(),
                                               vessel.getServiceTime(),
                                               vessel.getShipsTime());
                }

                if (vessel.getSize() == 2)
                {
                    storageMedShips.Rows.Add(vessel.getId(),
                                             vessel.getSize(),
                                             vessel.getServiceTime(),
                                             vessel.getShipsTime());
                }

                if (vessel.getSize() == 3)
                {
                    storageBigShips.Rows.Add(vessel.getId(),
                                             vessel.getSize(),
                                             vessel.getServiceTime(),
                                             vessel.getShipsTime());
                }
            }
        }

        public void showTime(int min, int hour, int day, int generalHour)
        {
            if (min < 10) minLabel.Text = "0" + min.ToString();
            else minLabel.Text = min.ToString();

            if (hour < 10) hourLabel.Text = "0" + hour.ToString();
            else hourLabel.Text = hour.ToString();

            if (day < 10) dayLabel.Text = "0" + day.ToString();
            else dayLabel.Text = day.ToString();

            allHours.Text = generalHour.ToString();
        }

        public void addVesselToRoadstead(Vessel vessel)
        {
            if (vessel != null)
                roadsteadData.Rows.Add(vessel.getId(),
                                       vessel.getSize(),
                                       vessel.getServiceTime(),
                                       vessel.getShipsTime());
        }

        public void addVesselsToPiers(Port port)
        {
            Pier firstPier = port.getPiers()[0];
            Pier secondPier = port.getPiers()[1];
            Pier thirdPier = port.getPiers()[2];
            Pier fourthPier = port.getPiers()[3];

            if (!firstPier.isFree)
            {
                firstPierServiceNow.Text = "id: " + firstPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + "size: " +
                                           firstPier.getCurrentServiceShip().getSize().ToString() + "service time: " +
                                           firstPier.getCurrentServiceShip().getServiceTime().ToString();
            }

            if (!secondPier.isFree)
            {
                secondPierServiceNow.Text = "id: " + secondPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + "size: " +
                                           secondPier.getCurrentServiceShip().getSize().ToString() + "service time: " +
                                           secondPier.getCurrentServiceShip().getServiceTime().ToString();
            }

            if (!thirdPier.isFree)
            {
                thirdPierServiceNow.Text = "id: " + thirdPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + "size: " +
                                           thirdPier.getCurrentServiceShip().getSize().ToString() + "service time: " +
                                           thirdPier.getCurrentServiceShip().getServiceTime().ToString();
            }

            if (!fourthPier.isFree)
            {
                fourthPierServiceNow.Text = "id: " + fourthPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + "size: " +
                                           fourthPier.getCurrentServiceShip().getSize().ToString() + "service time: " +
                                           fourthPier.getCurrentServiceShip().getServiceTime().ToString();
            }
        }

        public void removeVesselFromStorage(Vessel vessel)
        {
            if (vessel.getSize() == 1)
            {
                storageSmallShips.Rows.RemoveAt(searchDataRowById(vessel.getId(), storageSmallShips));
                storageSmallShips.Refresh();
            }

            if (vessel.getSize() == 2)
            {
                storageMedShips.Rows.RemoveAt(searchDataRowById(vessel.getId(), storageMedShips));
                storageMedShips.Refresh();
            }

            if (vessel.getSize() == 3)
            {
                storageBigShips.Rows.RemoveAt(searchDataRowById(vessel.getId(), storageBigShips));
                storageBigShips.Refresh();
            }
        }

        public int searchDataRowById(int id, DataGridView storageShips)
        {
            foreach (DataGridViewRow row in storageShips.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(id.ToString()))
                {
                    return row.Index;
                }
            }
            return -1;
        }

        public void removeVesselFromRoadstead(int id)
        {
            int index = searchDataRowById(id, roadsteadData);
            if (index != -1)
            {
                roadsteadData.Rows.RemoveAt(index);
            }
            roadsteadData.Refresh();
        }

        public void changePierData(Port port, int numberOfPier)
        {
            Pier firstPier = port.getPiers()[0];
            Pier secondPier = port.getPiers()[1];
            Pier thirdPier = port.getPiers()[2];
            Pier fourthPier = port.getPiers()[3];

            if (numberOfPier == 0)
            {
                firstPierTotalServ.Text = firstPier.getNumberOfShipsServ().ToString();
                firstPierSmallServ.Text = firstPier.getNumberOfSmallShipsServ().ToString();
                firstPierMedServ.Text = firstPier.getNumberOfMedShipsServ().ToString();
                firstPierLargeServ.Text = firstPier.getNumberOfLargeShipsServ().ToString();
            }

            if (numberOfPier == 1)
            {
                secondPierTotalServ.Text = secondPier.getNumberOfShipsServ().ToString();
                secondPierSmallServ.Text = secondPier.getNumberOfSmallShipsServ().ToString();
                secondPierMedServ.Text = secondPier.getNumberOfMedShipsServ().ToString();
                secondPierLargeServ.Text = secondPier.getNumberOfLargeShipsServ().ToString();
            }

            if (numberOfPier == 2)
            {
                thirdPierTotalServ.Text = thirdPier.getNumberOfShipsServ().ToString();
                thirdPierSmallServ.Text = thirdPier.getNumberOfSmallShipsServ().ToString();
                thirdPierMedServ.Text = thirdPier.getNumberOfMedShipsServ().ToString();
                thirdPierLargeServ.Text = thirdPier.getNumberOfLargeShipsServ().ToString();
            }

            if (numberOfPier == 3)
            {
                fourthPierTotalServ.Text = fourthPier.getNumberOfShipsServ().ToString();
                fourthPierSmallServ.Text = fourthPier.getNumberOfSmallShipsServ().ToString();
                fourthPierMedServ.Text = fourthPier.getNumberOfMedShipsServ().ToString();
                fourthPierLargeServ.Text = fourthPier.getNumberOfLargeShipsServ().ToString();
            }
        }

        public void cleanPier(int pierNumber)
        {
            if (pierNumber == 0)
            {
                firstPierServiceNow.Text = "";

            }

            if (pierNumber == 1)
            {
                secondPierServiceNow.Text = "";
            }

            if (pierNumber == 2)
            {
                thirdPierServiceNow.Text = "";
            }

            if (pierNumber == 3)
            {
                fourthPierServiceNow.Text = "";
            }
        }

        public void stopTime()
        {
            timer1.Enabled = false;
        }

        public void showMiddleAverage(double smallVesselMiddleTime,
                                      double medVesselMiddleTime,
                                      double largeVesselMiddleTime)
        {
            smallShipMiddleTime.Text = smallVesselMiddleTime.ToString();
            medShipMiddleTime.Text = medVesselMiddleTime.ToString();
            largeShipMiddleTime.Text = largeVesselMiddleTime.ToString();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timerButton.Enabled = true;
            buttonStart.Enabled = false;

            presenter.initFacade(Convert.ToInt32(smallShipsCount.Text),
                                 Convert.ToInt32(mediumShipsCount.Text),
                                 Convert.ToInt32(largeShipsCount.Text),
                                 Convert.ToInt32(smallShipsServiceTime.Text),
                                 Convert.ToInt32(mediumShipsServiceTime.Text),
                                 Convert.ToInt32(largeShipsServiceTime.Text),
                                 Convert.ToInt32(shipsTime.Text));

            presenter.loadVesselStorage();


            // Блокирует поля для ввода исходных данных
            smallShipsCount.ReadOnly = true;
            mediumShipsCount.ReadOnly = true;
            largeShipsCount.ReadOnly = true;
            smallShipsServiceTime.ReadOnly = true;
            mediumShipsServiceTime.ReadOnly = true;
            largeShipsServiceTime.ReadOnly = true;
            shipsTime.ReadOnly = true;
        }

        /*public void showVesselStorage(string vesselStorage)
        {
            testLabel.Text = vesselStorage;
        }*/

        // Реализация секундомера
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            presenter.changeTime();

            presenter.loadTime();

            // Добавляет суда в рейд и удаляет из вкладки "Обслуживаемые судна"
            presenter.loadVesselToRoadstead();

            // Добавление судов на причалы
            presenter.loadVesselToPiers();

            // Удаление судов с причалов
            presenter.removeVesselFromPier();

            presenter.checkStopTime(Convert.ToInt32(smallShipsCount.Text),
                                    Convert.ToInt32(mediumShipsCount.Text),
                                    Convert.ToInt32(largeShipsCount.Text));
        }

        // Кнопки ускорения секундомера
        private void buttonX1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            timer1.Interval = 20;
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10;
        }

        // Проверка ввода текста
        private void input_TextChanged(object sender, EventArgs e)
        {
            buttonStart.Enabled = FormUtils.checkFillFields(smallShipsCount,
                                                            mediumShipsCount,
                                                            largeShipsCount,
                                                            smallShipsServiceTime,
                                                            mediumShipsServiceTime,
                                                            largeShipsServiceTime,
                                                            shipsTime);
        }

        // Проверка, что вводятся только цифры
        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        // Кнопка Stop(Resume)
        private void timerButton_Click(object sender, EventArgs e)
        {
            if (timerButton.Text == "Stop")
            {
                timer1.Enabled = false;
                timerButton.Text = "Resume";
            }
            else
            {
                timer1.Enabled = true;
                timerButton.Text = "Stop";
            }
        }
    }
}
