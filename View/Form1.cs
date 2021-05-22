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

        public void addVesselsToStorage(VesselStorage storage)
        {
            foreach(Vessel vessel in storage.getVessels())
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

        public void addVesselsToStorage(Port port)
        {
            Pier firstPier = port.getPiers()[0];
            Pier secondPier = port.getPiers()[1];
            Pier thirdPier = port.getPiers()[2];
            Pier fourthPier = port.getPiers()[3];

            if (!firstPier.isFree)
            {
                firstPierServiceNow.Text = firstPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + firstPier.getCurrentServiceShip().getSize().ToString();
            }

            if (!secondPier.isFree)
            {
                secondPierServiceNow.Text = secondPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + secondPier.getCurrentServiceShip().getSize().ToString();
            }

            if (!thirdPier.isFree)
            {
                thirdPierServiceNow.Text = thirdPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + thirdPier.getCurrentServiceShip().getSize().ToString();
            }

            if (!fourthPier.isFree)
            {
                fourthPierServiceNow.Text = fourthPier.getCurrentServiceShip().getId().ToString() +
                                           "; " + fourthPier.getCurrentServiceShip().getSize().ToString();
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

        // Реализация секундомера
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            presenter.changeTime();

            presenter.loadTime();

            presenter.loadVesselToRoadstead();

            // Добавление судов на причалы
            presenter.loadVesselToPiers();

            // Удаление судов с рейда
            // presenter.removeVesselFromPiers();

            // Удаление судов с причалов
            // presenter.removeVesselFromPiers();

            //controller.setMin(this.min);
            //controller.setHour(this.hour);
            //controller.setDay(this.day);

            // Добавление в рейд
            //if (this.hour % Convert.ToInt32(shipsTime.Text) == 0)
            {
                //Vessel currentVessel = controller.getVesselStorage().getVessel();

                //controller.getRoadstead().pushVessel(currentVessel);

                //roadsteadData.Rows.Add(currentVessel.getId(), currentVessel.getSize(), currentVessel.getServiceTime());
            }
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

        // Геттеры для входных данных
        /*public string getSmallShipsCount()
        {
            return smallShipsCount.Text;
        }

        public string getMediumShipsCount()
        {
            return mediumShipsCount.Text;
        }

        public string getLargeShipsCount()
        {
            return largeShipsCount.Text;
        }

        public string getSmallShipsServiceTime()
        {
            return smallShipsServiceTime.Text;
        }

        public string getMedShipsServiceTime()
        {
            return mediumShipsServiceTime.Text;
        }
        public string getLargeShipsServiceTime()
        {
            return largeShipsServiceTime.Text;
        }
        public string getShipsTime()
        {
            return shipsTime.Text;
        }*/
    }
}
