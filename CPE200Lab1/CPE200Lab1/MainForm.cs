using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate,oper,operm,keep1,keep2;
        private bool has2,percen ;
        private double sum = 0;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            has2 = false;
        }

        private string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            keep2 = secondOperand;



            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if(secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if(parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    double q = Convert.ToDouble(firstOperand);
                    double w = Convert.ToDouble(secondOperand);

                    //      double q = (firstOperand);
                    //     double w = Convert.ToDouble(secondOperand);
                    double e = q * w / 100;
                   
                    switch (oper)
                        {
                         
                            case "+":
                                return (q + e).ToString();
                            case "-":
                                return (q - e).ToString();
                            case "X":
                                return (q * e).ToString();
                            case "÷":
                                // Not allow devide be zero
                                if (secondOperand != "0")
                                {
                                    double result;
                                    string[] parts;
                                    int remainLength;

                                    result = (q / e);
                                    // split between integer part and fractional part
                                    parts = result.ToString().Split('.');
                                    // if integer part length is already break max output, return error
                                    if (parts[0].Length > maxOutputSize)
                                    {
                                        return "E";
                                    }
                                    // calculate remaining space for fractional part.
                                    remainLength = maxOutputSize - parts[0].Length - 1;
                                    // trim the fractional part gracefully. =
                                    return result.ToString("N" + remainLength);
                                }
                                break;
                           
                                
                        }
                        
                        break;
            }
            return "E";

            
            // return "E";
            percen = true;
        }
        
        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";

                has2 = true;
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            operate = ((Button)sender).Text;

            if (has2 == true )
            {
                
                string secondOperand = lblDisplay.Text;
                string result = calculate(operate, firstOperand, secondOperand); ///3232332323232323232
                double m = Convert.ToDouble(result);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
                has2 = false;
                isAfterOperater = false;

            }
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            
            switch (operate)
            {
                case "+":  oper = "+";
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    break;
                case "-": oper = "-";
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    break;
                case "X": oper = "X";
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    break;
                case "÷": oper = "÷";
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    break;


                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                 
                    percen = true;
                    isAfterOperater = true;
                    break;
               
                
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            has2 = false;
            isAfterOperater = false;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            
            string secondOperand = lblDisplay.Text;   ///*********************************เก็บค่าเลข 2

            if (isAfterEqual == true)
            {
                secondOperand = keep2;
                
            }
            string result = calculate(operate, firstOperand, secondOperand); ///*****************คำนวนน

            
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            
           
            isAfterEqual = true;
            firstOperand = result;
            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            operm = ((Button)sender).Text;
            if (has2 == true)
            {

                string secondOperand = lblDisplay.Text;
                keep2 = secondOperand;
                string result = calculate(operate, firstOperand, secondOperand); ///3232332323232323232
               // double m = Convert.ToDouble(lblDisplay.Text);
                operate = "";
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
                if (operm == "M+")
                {
                    sum += Convert.ToDouble(lblDisplay.Text);
                }
                if (operm == "M-")
                {
                    sum -= Convert.ToDouble(lblDisplay.Text);
                }
                operate = "";
                has2 = false;
            }
            switch(operm)
            {
                case "MR":
                    lblDisplay.Text = sum.ToString();
                    break;
                case "MC":
                    sum = 0;
                    break;
                case "MS":
                    sum = Convert.ToDouble(lblDisplay.Text); 
                    break;
                case "M+":
                    if(has2 == false)
                    {
                        sum += Convert.ToDouble(lblDisplay.Text);
                    }
                    break;
                case "M-":
                    if (has2 == false)
                    {
                        sum -= Convert.ToDouble(lblDisplay.Text);
                    }
                    break;
                case "1/x":
                    lblDisplay.Text = (1 / (Convert.ToDouble(lblDisplay.Text))).ToString();
                    break;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }
    }
}
