using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var calcBtn = new Button();
            calcBtn.Location = new System.Drawing.Point(128, 214);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new System.Drawing.Size(75, 23);
            calcBtn.TabIndex = 1;
            calcBtn.Text = "Calculate";
            calcBtn.UseVisualStyleBackColor = true;

            this.Controls.Add(calcBtn);

            calcBtn.Click += (sender, args) =>
            {
                MessageBox.Show("Some stuff");
                Close();
            };



            
        }
    }
}
