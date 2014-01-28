using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Branching
{
    public partial class Branching : Form
    {
        public Branching()
        {
            InitializeComponent();

            // Unconditional branching methods.
            // return
            doReturnNoValue();
            doReturnWithValue();

            // break
            doBreak();

            // goto
            doGotoWithLabel();
            doGotoWithSwitch();

            // continue
            doContinue();

            // throw
            doThrow();
        }

        private void doReturnNoValue()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            int testVariable = 3;
            int compareVariable = 4;

            if (compareVariable > testVariable)
            {
                if (testVariable < 10)
                {
                    outputListBox.Items.Add("Return from if");
                    return;
                }
                else
                {
                    // Do some more checking.
                    switch (testVariable)
                    {
                        case 1:
                            outputListBox.Items.Add("Return from switch case 1");
                            return;
                        case 2:
                            outputListBox.Items.Add("Return from switch case 2");
                            return;
                        default:
                            testVariable++;
                            break;
                    }
                }
            }
            outputListBox.Items.Add("Normal method termination");
        }

        private bool doReturnWithValue()
        {
            bool result = false;

            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            int myAge = 18;

            if (myAge > 21)
                result = true;
            else if (myAge >= 18)
            {
                // Do some more checking.
                switch (myAge)
                {
                    case 18:
                        outputListBox.Items.Add("Return false from switch case 18");
                        return false;
                    case 19:
                        outputListBox.Items.Add("Return true from switch case 19");
                        return true;
                    case 20:
                        outputListBox.Items.Add("Return false from switch case 20");
                        return false;
                    default:
                        myAge++;
                        break;
                }
            }

            outputListBox.Items.Add("Normal method termination, return value is " + result);
            return result;
        }

        private void doBreak()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            int partialCount = 0;

            // while (or do) 
            while (true)
            {
                if (partialCount > 5)
                    break;
                partialCount++;
            }

            // for (or foreach)
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    break;
                partialCount++;
            }

            // switch
            switch (partialCount)
            {
                case 5:
                    partialCount *= 5;
                    break;
                case 10:
                    partialCount *= 10;
                    break;
                default:
                    partialCount++;
                    break;
            }

            outputListBox.Items.Add("Partial count: " + partialCount);
        }


        private void doGotoWithLabel()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            int anyNumber = 3;

            if (anyNumber % 2 == 0)
                goto Even;
            else
                goto Odd;

        Odd:
            outputListBox.Items.Add("The number is odd");
            goto Finish;
        Even:
            outputListBox.Items.Add("The number is even");

        Finish:
            outputListBox.Items.Add("Conclusion");

        }

        private void doGotoWithSwitch()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            string dayOfWeek = "Saturday";
            bool isWeekend = true;

            switch (dayOfWeek)
            {
                case "Saturday":
                    isWeekend = true;
                    break;
                case "Sunday":
                    goto case "Saturday";
                case "Monday":
                    isWeekend = false;
                    break;
                case "Tuesday":
                    goto case "Monday";
                case "Wednesday":
                    goto case "Monday";
                case "Thursday":
                    goto case "Monday";
                case "Friday":
                    goto case "Monday";
                default:
                    outputListBox.Items.Add(dayOfWeek + " is not a valid week day");
                    break;
            }

            outputListBox.Items.Add(dayOfWeek + (isWeekend ? " is " : " is not") + "a week day");
        }

        private void doContinue()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);

            int startNumber = 3;
            int endNumber = 100;
            int count = 0;

            for (int i = startNumber; i <= endNumber; i++)
            {
                // Only cound odd numbers
                if (i % 2 == 0)
                    continue;
                count++;
            }

            outputListBox.Items.Add("Odd number count: " + count);
        }

        private void doThrow()
        {
            // Get method name.
            outputListBox.Items.Add("=> Method: " + System.Reflection.MethodInfo.GetCurrentMethod().Name);


            int numerator = 10;
            int denominator = 0;
            int result = 0;

            try
            {
                if (denominator == 0)
                    throw new DivideByZeroException();
                else
                    result = numerator / denominator;
            }
            catch (Exception ex)
            {
                outputListBox.Items.Add(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
