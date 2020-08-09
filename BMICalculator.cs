using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace COMP123_M2020_Assignment4
{
    public partial class BMICalculator : Form
    {
        public BMICalculator()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3000);          
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void BMICalculateForm_Load(object sender, EventArgs e)
        {
           
        }

        private void radioButton_Check(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            
            if(rdo.Name == "radioImperial")
            {
                lblHeight.Text = "in";
                lblWeight.Text = "lb";
            }
            else if (rdo.Name == "radioMetric")
            {
                lblHeight.Text = "m";
                lblWeight.Text = "kg";
            }
           
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            RadioButton rdo = sender as RadioButton;

            double height = Convert.ToDouble(txtHeight.Text);
            double weight = Convert.ToDouble(txtWeight.Text);

            if (btn.Name == "btnCalculate" && radioImperial.Checked == true)
            {                
                double calc = (weight * 703) / (height * height);
                double result = Math.Round(calc, 3);
                
                if (result < 25 && result > 18.5)
                {
                    resultBox.ForeColor = Color.DarkGreen;
                }
                else if (result >= 30)
                {
                    resultBox.ForeColor = Color.Firebrick;
                }
                else
                {
                    resultBox.ForeColor = Color.Orange;
                }

                resultBox.Text = result.ToString();
            }
            
            else if (btn.Name == "btnCalculate" && radioMetric.Checked == true)
            {
                double calc = (weight) / (height * height);
                double result = Math.Round(calc, 3);

                if (result < 25 && result > 18.5)
                {
                    resultBox.ForeColor = Color.DarkGreen;
                }
                else if (result >= 30)
                {
                    resultBox.ForeColor = Color.Firebrick;
                }
                else
                {
                    resultBox.ForeColor = Color.Orange;
                }

                resultBox.Text = result.ToString();
            }

            else if (btn.Name == "btnReset")
            {
                txtHeight.Text = "";
                txtWeight.Text = "";
                resultBox.Text = "";
            }
            
        }
    }
}
