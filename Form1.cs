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

namespace RiverPortApp
{
    public partial class Form1 : Form
    {
        private int min = 0;

        private int hour = 0;

        private int day = 0;

        private Controller controller;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            controller = new Controller(Convert.ToInt32(smallShipsCount.Text),
                                        Convert.ToInt32(mediumShipsCount.Text),
                                        Convert.ToInt32(largeShipsCount.Text),
                                        Convert.ToInt32(smallShipsServiceTime.Text),
                                        Convert.ToInt32(mediumShipsServiceTime.Text),
                                        Convert.ToInt32(largeShipsServiceTime.Text),
                                        Convert.ToInt32(shipsTime.Text));

            testLabel.Text = controller.getVesselStorage().getStringVessels();

            // Запрещает добавление в таблицу строк пользователем
            roadsteadData.AllowUserToAddRows = false;
            roadsteadData.AllowUserToDeleteRows = false;
            roadsteadData.ReadOnly = true;

            //roadsteadData.Rows.Add("15326", "2", "25");

            smallShipsCount.ReadOnly = true;
            mediumShipsCount.ReadOnly = true;
            largeShipsCount.ReadOnly = true;
            smallShipsServiceTime.ReadOnly = true;
            mediumShipsServiceTime.ReadOnly = true;
            largeShipsServiceTime.ReadOnly = true;
            shipsTime.ReadOnly = true;
        }

        // Реализация секундомера
        private void timer1_Tick_1(object sender, EventArgs e)
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

            if (this.min < 10) minLabel.Text = "0" + this.min.ToString();
            else minLabel.Text = this.min.ToString();

            if (this.hour < 10) hourLabel.Text = "0" + this.hour.ToString();
            else hourLabel.Text = this.hour.ToString();

            if (this.day < 10) dayLabel.Text = "0" + this.day.ToString();
            else dayLabel.Text = this.day.ToString();

            // Добавление в рейд
            if (this.hour % Convert.ToInt32(shipsTime.Text) == 0)
            {
                Vessel currentVessel = controller.getVesselStorage().getVessel();

                if (controller.getVesselStorage().getVessels().Count == 0) timer1.Enabled = false;

                roadsteadData.Rows.Add(currentVessel.getId(), currentVessel.getSize(), currentVessel.getServiceTime());
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
        public string getSmallShipsCount()
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
        }
    }
}
