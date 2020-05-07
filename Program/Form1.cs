using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //creates calc and reset button for RR
            var calcBtn = new Button();
            calcBtn.Location = new System.Drawing.Point(230, 270);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new System.Drawing.Size(75, 23);
            calcBtn.TabIndex = 1;
            calcBtn.Text = "Calculate";
            calcBtn.UseVisualStyleBackColor = true;
            var resetBtn = new Button();
            resetBtn.Location = new System.Drawing.Point(230, 300);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new System.Drawing.Size(75, 23);
            resetBtn.TabIndex = 2;
            resetBtn.Text = "Reset";
            resetBtn.UseVisualStyleBackColor = true;

            //puts border on table cells
            this.RRScheduling.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            this.MLQScheduling.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            this.Controls.Add(calcBtn);
            this.Controls.Add(resetBtn);

            // name of the process 
            String[] name = { "p1", "p2", "p3", "p4", "p5", "p6" };

            // arrival for every process 
            int[] arrivaltime = { 0, 25, 30, 50, 100, 105 };

            // burst time for every process 
            int[] bursttime = { 15, 25, 20, 15, 15, 10 };

            //priority for each process
            int[] priority = { 40, 30, 30, 35, 5, 10 };

            // quantum time of each process 
            int q = 10;

            //adds 1 to time quantum
            plusQ.Click += (sender, args) =>
            {
                q += 1;
                //sets time quantum to timeQ label
                timeQ.Text = q.ToString();
            };

            //minus' 1 from time quantum
            minusQ.Click += (sender, args) =>
            {
                if (q > 1) {
                    q -= 1;
                }
                //sets time quantum to timeQ label
                timeQ.Text = q.ToString();
            };

            // quantum time1 of each process 
            int q1 = 3;

            //adds 1 to time quantum1
            plusQ1.Click += (sender, args) =>
            {
                q1 += 1;
                //sets time quantum1 to timeQ1 label
                timeQ1.Text = q1.ToString();
            };

            //minus' 1 from time quantum1
            minusQ1.Click += (sender, args) =>
            {
                if (q1 > 1)
                {
                    q1 -= 1;
                }
                //sets time quantum1 to timeQ1 label
                timeQ1.Text = q1.ToString();
            };

            // quantum time1 of each process 
            int q2 = 4;

            //adds 1 to time quantum1
            plusQ2.Click += (sender, args) =>
            {
                q2 += 1;
                //sets time quantum1 to timeQ1 label
                timeQ2.Text = q2.ToString();
            };

            //minus' 1 from time quantum1
            minusQ2.Click += (sender, args) =>
            {
                if (q2 > 1)
                {
                    q2 -= 1;
                }
                //sets time quantum1 to timeQ1 label
                timeQ2.Text = q2.ToString();
            };

            //connects Program.cs for roundRobin method
            Program RR = new Program();
            

            //calculates round Robin Scheduling
            calcBtn.Click += (sender, args) =>
            {
                ganntChart.Text = "";
                ATaT.Text = "0";
                AWT.Text = "0";
                RR.Gannt = "";
                RR.TaT = 0;
                RR.WaitT = 0;
                RR.roundRobin(name, arrivaltime, bursttime, priority, q);
                ganntChart.Text = RR.Gannt;
                ATaT.Text = RR.TaT.ToString();
                AWT.Text = RR.WaitT.ToString();
            };

            //resets round Robin Scheduling and time quantum
            resetBtn.Click += (sender, args) =>
            {
                q = 10;
                //sets time quantum to timeQ label
                ATaT.Text = "0";
                AWT.Text = "0";
                RR.Gannt = "";
                RR.TaT = 0;
                RR.WaitT = 0;
                timeQ.Text = q.ToString();
                ganntChart.Text = "";
            };




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Burst_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }
    }
}
