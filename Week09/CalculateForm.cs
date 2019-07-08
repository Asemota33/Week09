using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week09
{
    public partial class CalculateForm : Form
    {
        /// <summary>
        /// Constructor for calculateForm
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the chared Event handler for all the calculator buttons click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button;

            int buttonValue;
            bool resultCondition = int.TryParse(TheButton.Text, out buttonValue);

            if (resultCondition)
            {
                resultLabel.Text += TheButton.Text;
            }
            else
            {
                resultLabel.Text = "Not a number (NaN)";
            }
        }

        private void CalculateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
