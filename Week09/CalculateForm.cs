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
        // class properties
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }

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
            var tag = TheButton.Tag.ToString();

            bool resultCondition = int.TryParse(tag, out buttonValue);
            // If user pressed a number button
            if (resultCondition)
            {
                int maxsize = 3;
                if (decimalExists)
                {
                    maxsize = 5;
                }

                if (outputString != string.Empty && resultLabel.Text.Count() < maxsize)
                {
                    outputString += tag;
                    resultLabel.Text = outputString;
                }
            }

            //if user presses a button thats not a number
            if (!resultCondition)
            {
                switch (tag)
                {
                    case "clear":
                        ClearNumericKeyboard();
                        break;
                    case "back":
                        removeLastCharacterFromResultLabel();
                        break;
                    case "done":
                        finalizeOutput();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }
            
        }
        /// <summary>
        /// This method adds a decimal to the result label
        /// </summary>
        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                if (resultLabel.Text == "0")
                {
                    outputString += "0";
                }
                outputString += ".";
                decimalExists = true;
            }
        }
        /// <summary>
        /// This method sends the output to the test label
        /// </summary>
        private void finalizeOutput()
        {
            outputValue = float.Parse(outputString);
            if (outputString == string.Empty)
            {
                outputString = "0";
            }
            heightLabel.Text = outputString.ToString();
            ClearNumericKeyboard();
            removeLastCharacterFromResultLabel();
            calculatorButtonTableLayoutPanel.Visible = false;
        }

        /// <summary>
        /// This method removes the last character from the results label
        /// </summary>
        private void removeLastCharacterFromResultLabel()
        {
            if (outputString.Length > 0)
            {


                var lastChar = outputString.Substring(outputString.Length - 1);
                if (lastChar == ".")
                {
                    decimalExists = false;
                }
                outputString = outputString.Remove(outputString.Length - 1);
                if(outputString.Length == 0)
                {
                    outputString = "0";
                }
                resultLabel.Text = outputString;
            }
        }

        /// <summary>
        /// This method clears the numeric keyboard
        /// </summary>
        private void ClearNumericKeyboard()
        {
            resultLabel.Text = "0";
            outputString = string.Empty;
            decimalExists = false;
            outputValue = 0;
           
        }

        /// <summary>
        /// This is the event handler that triggers when the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateForm_Load(object sender, EventArgs e)
        {
            ClearNumericKeyboard();
            calculatorButtonTableLayoutPanel.Visible = true;
        }

        /// <summary>
        /// This is the event handler fot the
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heightLabel_Click(object sender, EventArgs e)
        {
            calculatorButtonTableLayoutPanel.Visible = true;
        }
    }
}
