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

            presenter.initFacade(Convert.ToInt32(smallShipsCount.Text),
                                 Convert.ToInt32(mediumShipsCount.Text),
                                 Convert.ToInt32(largeShipsCount.Text),
                                 Convert.ToInt32(smallShipsServiceTime.Text),
                                 Convert.ToInt32(mediumShipsServiceTime.Text),
                                 Convert.ToInt32(largeShipsServiceTime.Text),
                                 Convert.ToInt32(shipsTime.Text));
            presenter.loadVesselStorage();

            // Запрещает добавление в таблицу строк пользователем
            roadsteadData.AllowUserToAddRows = false;
            roadsteadData.AllowUserToDeleteRows = false;
            roadsteadData.ReadOnly = true;

            //roadsteadData.Rows.Add("15326", "2", "25");

            // Блокирует поля для ввода исходных данных
            smallShipsCount.ReadOnly = true;
            mediumShipsCount.ReadOnly = true;
            largeShipsCount.ReadOnly = true;
            smallShipsServiceTime.ReadOnly = true;
            mediumShipsServiceTime.ReadOnly = true;
            largeShipsServiceTime.ReadOnly = true;
            shipsTime.ReadOnly = true;
        }

        public void showVesselStorage(string vesselStorage)
        {
            testLabel.Text = vesselStorage;
        }

        public void showTime(int min, int hour, int day)
        {
            if (min < 10) minLabel.Text = "0" + min.ToString();
            else minLabel.Text = min.ToString();

            if (hour < 10) hourLabel.Text = "0" + hour.ToString();
            else hourLabel.Text = hour.ToString();

            if (day < 10) dayLabel.Text = "0" + day.ToString();
            else dayLabel.Text = day.ToString();
        }

        // Реализация секундомера
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            presenter.changeTime();

            presenter.loadTime();

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

        // Ускорение секундомера
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
