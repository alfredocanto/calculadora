using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double Number1 = 0;
        double Number2 = 0;
        char Operator;
        public Form1()
        {
            InitializeComponent();
            tbDisplay.MaxLength = 15;
            this.MaximumSize = new Size(358, 447); // Set the maximum size
            this.MinimumSize = new Size(358, 447); // Set the minimum size
        }

        private void AddNumber(object sender, EventArgs e)
        {
            var button = ((Button)sender);

            if (tbDisplay.Text == "0")
            {
                tbDisplay.Text = "";
            }

            tbDisplay.Text += button.Text;
            
        }

        private void clickOperator(object sender, EventArgs e)
        {
            var button = ((Button)sender);

            Number1 = Convert.ToDouble(tbDisplay.Text);
            Operator = Convert.ToChar(button.Tag);

            if (Operator == '²')
            {
                Number1 = Math.Pow(Number1, 2);
                tbDisplay.Text = Number1.ToString();
            }
            else if (Operator == '√')
            {
                Number1 = Math.Sqrt(Number1);
                tbDisplay.Text = Number1.ToString();
            }
            else
            {
                tbDisplay.Text = "0";
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Number2 = Convert.ToDouble(tbDisplay.Text);

            if (Operator == '+')
            {
                tbDisplay.Text = (Number1 + Number2).ToString();
                Number1 = Convert.ToDouble(tbDisplay.Text);
            }
            else if (Operator == '-')
            {
                tbDisplay.Text = (Number1 - Number2).ToString();
                Number1 = Convert.ToDouble(tbDisplay.Text);
            }
            else if (Operator == 'X')
            {
                tbDisplay.Text = (Number1 * Number2).ToString();
                Number1 = Convert.ToDouble(tbDisplay.Text);
            }
            else if (Operator == '∕')
            {
                if(tbDisplay.Text != "0")
                {
                    tbDisplay.Text = (Number1 / Number2).ToString();
                    Number1 = Convert.ToDouble(tbDisplay.Text);
                }
                else
                {
                    MessageBox.Show("No se puede dividir por cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text.Length > 1)
            {
                tbDisplay.Text = tbDisplay.Text.Substring(0, tbDisplay.Text.Length - 1);
            }
            else
            {
                tbDisplay.Text = "0";
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Number1 = 0;
            Number2 = 0;
            Operator = '\0';
            tbDisplay.Text = "0";
        }

        private void btnDeleteOperation_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "0";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!tbDisplay.Text.Contains("."))
            {
                tbDisplay.Text += ",";
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Number1 = Convert.ToDouble(tbDisplay.Text);
            Number1 *= -1;
            tbDisplay.Text = Number1.ToString();
        }
    }
}
