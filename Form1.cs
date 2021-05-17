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

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
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
            buttonStart.Enabled = ControllerUtils.checkFillFields(smallShipsCount,
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
    }
}
