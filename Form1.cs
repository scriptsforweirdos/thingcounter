using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thing_Counter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrLabel1.Text = Properties.Settings.Default.Counter1Name;
            labelResult.Text = Properties.Settings.Default.Counter1Value.ToString();

            ctrLabel2.Text = Properties.Settings.Default.Counter2Name;
            labelResult2.Text = Properties.Settings.Default.Counter2Value.ToString();

            ctrLabel3.Text = Properties.Settings.Default.Counter3Name;
            labelResult3.Text = Properties.Settings.Default.Counter3Value.ToString();
        }

        // Increment Buttons
        private void button2_Click(object sender, EventArgs e)
        {
            // get the current number, add 1 to it
            // change the result
            increment(labelResult, 1);
        }

        private void btnIncrease2_Click(object sender, EventArgs e)
        {
            increment(labelResult2, 2);
        }

        private void btnIncrease3_Click(object sender, EventArgs e)
        {
            increment(labelResult3, 3);
        }

        // Decrement Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            decrement(labelResult, 1);
        }


        private void btnDecrease2_Click(object sender, EventArgs e)
        {
            decrement(labelResult2, 2);
        }

        private void btnDecrease3_Click(object sender, EventArgs e)
        {
            decrement(labelResult3, 3);
        }

        // reset Buttons
        private void button3_Click(object sender, EventArgs e)
        {
            resetlabel(labelResult, 1);
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            resetlabel(labelResult2, 2);
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            resetlabel(labelResult3, 3);
        }

        // Edit Buttons
        private void btnEdit1_Click(object sender, EventArgs e)
        {
            // show the textbox and save button
            showtextbox(ctrLabel1, textLabel1, btnSave1);

        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            // show the textbox and save button
            showtextbox(ctrLabel2, textLabel2, btnSave2);
        }

        private void btnEdit3_Click(object sender, EventArgs e)
        {
            // show the textbox and save button
            showtextbox(ctrLabel3, textLabel3, btnSave3);
        }

        // Save buttons (hidden unless edit buttons are clicked)
        private void btnSave1_Click(object sender, EventArgs e)
        {
            // Save Textbox
            savenewlabel(ctrLabel1, textLabel1, btnSave1, 1);

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            // Save Textbox
            savenewlabel(ctrLabel2, textLabel2, btnSave2, 2);
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            // Save Textbox
            savenewlabel(ctrLabel3, textLabel3, btnSave3, 3);
        }

        // actual behavior begins here
        private void increment(Label label, int counterNo)
        {
            int currentNumber = Int32.Parse(label.Text);
            int newNumber = currentNumber + 1;

            label.Text = newNumber.ToString();

            switch (counterNo)
            {
                case 1:
                    Properties.Settings.Default.Counter1Value = newNumber;
                    break;
                case 2:
                    Properties.Settings.Default.Counter2Value = newNumber;
                    break;
                case 3:
                    Properties.Settings.Default.Counter3Value = newNumber;
                    break;
            }
            Properties.Settings.Default.Save();

        }

        private void decrement(Label label, int counterNo)
        {
            /* We have to define newnumber here 
             * as it's used multiple times */
            int newNumber;
            int currentNumber = Int32.Parse(label.Text);

            // only decrement to 0
            if (currentNumber > 0)
            {
                newNumber = currentNumber - 1;
            }
            else
            {
                newNumber = 0;
            }

            label.Text = newNumber.ToString();

            switch(counterNo)
            {
                case 1:
                    Properties.Settings.Default.Counter1Value = newNumber;
                    break;
                case 2:
                    Properties.Settings.Default.Counter2Value = newNumber;
                    break;
                case 3:
                    Properties.Settings.Default.Counter3Value = newNumber;
                    break;
            }
            
            Properties.Settings.Default.Save();

        }

        private void resetlabel(Label label, int counterNo)
        {
            // show a message box
            DialogResult dr = MessageBox.Show("Reset to 0?", "Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            // if yes
            if (dr == DialogResult.OK)
            {
                label.Text = "0";

                switch (counterNo) {
                    case 1:
                        Properties.Settings.Default.Counter1Value = 0;
                        break;
                    case 2:
                        Properties.Settings.Default.Counter2Value = 0;
                        break;
                    case 3:
                        Properties.Settings.Default.Counter3Value = 0;
                        break;
                }
                Properties.Settings.Default.Save();
            }

        }

        private void showtextbox(Label label, TextBox txt, Button btn)
        {
            string oldName = label.Text;

            // hide the label
            label.Visible = false;

            // put the oldName in the text box
            txt.Text = oldName;

            // show the edit box and save button
            txt.Visible = true;
            btn.Visible = true;
        }

        private void savenewlabel(Label label, TextBox txt, Button btn, int counterNo)
        {
            // Get the new value from the textbox
            string newName = txt.Text;

            // Set the label to the new value
            label.Text = newName;

            // hide the text box and save button
            txt.Visible = false;
            btn.Visible = false;

            // Show the label
            label.Visible = true;

            // Save the counter name to settings
            switch (counterNo)
            {
                case 1:
                    Properties.Settings.Default.Counter1Name = newName;
                    break;
                case 2:
                    Properties.Settings.Default.Counter2Name = newName;
                    break;
                case 3:
                    Properties.Settings.Default.Counter3Name = newName;
                    break;
            }
            Properties.Settings.Default.Save();
        }


    }

}
