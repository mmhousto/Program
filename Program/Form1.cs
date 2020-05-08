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
            //creates calc and reset button
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

            this.Controls.Add(calcBtn);
            this.Controls.Add(resetBtn);

            // Round Robin variables
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


            /*
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
            */


            // This is temporary stuff to help test multilevel queue code:
            // name of the process 
            String[] _name = { "p1", "p2", "p3", "p4", "p5" };

            // arrival for every process 
            int[] _arrivaltime = { 0, 4, 5, 12, 18 };

            // burst time for every process 
            int[] _bursttime = { 12, 8, 6, 5, 10 };

            //priority for each process
            int[] _priority = { 1, 2, 1, 2, 2 };

            // quantum time of each process 
            int q1 = 3;
            int q2 = 4;

            // Multilevel Queue
            Program MLQ = new Program();
            calcBtn.Click += (sender, args) =>
            {
                ganntChart.Text = "";
                MLQ.Gannt = "";
                MLQ.multiLevel(_name, _arrivaltime, _bursttime, _priority, q1, q2);
                ganntChart.Text = MLQ.Gannt;
            };

            // Reset
            resetBtn.Click += (sender, args) =>
            {
                //q = 10;
                //sets time quantum to timeQ label
                MLQ.Gannt = "";
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
    }
}
