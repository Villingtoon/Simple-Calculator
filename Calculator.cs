using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        double numOne = 0;
        double numTwo = 0;
        string operation;
        bool science = false;
        const int widthSmall = 422;
        const int widthLarge = 786;
        double result = 0;
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.Black;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            Display.BackColor = Color.Black;
            Display.ForeColor = Color.White;
            Display.TabStop = false;
            Display.Text = "0";

            string buttonName = null;
            Button button = null;
            for(int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(".");
            if (!weHaveDot)
            {
                if(Display.Text == string.Empty)
                {
                    Display.Text += "0.";
                }
                else
                {
                    Display.Text += ".";
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "0";
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = Convert.ToString(number);
            }
            catch
            {

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);

            if (button.Text == "Sqrt")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }

            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            numTwo = Convert.ToDouble(Display.Text);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "*")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^")
            {
                result = Math.Pow(numOne, numTwo);
            }

            Display.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            numOne = 0;
            numTwo = 0;
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (science)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            science = !science;
        }
    }
}
