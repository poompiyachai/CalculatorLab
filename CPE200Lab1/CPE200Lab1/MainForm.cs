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
        static public string operate,oper,operm,keep1,keep2;
        private bool has2,percen ;
        private double sum = 0;
        private bool check;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            has2 = false;
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

            if (((Button)sender).Text == "%")
            {
                percen = true;
            }
            if (has2 == true  )
            {
              
                string secondOperand = lblDisplay.Text;
                if(percen == true)
                {
                    secondOperand = (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                }
                string result = CalculateEngine.calculate(operate, firstOperand, secondOperand); ///3232332323232323232
                double m = Convert.ToDouble(result);
                percen = false;
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
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "%": operate = "%";
                    break;
                    
                    
                case "+": 
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    operate = "+";
                    break;
                case "-": 
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    operate = "-";
                    break;
                case "X": 
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    operate = "X";
                    break;
                case "÷": 
                    firstOperand = lblDisplay.Text; //////////////////////////////must use
                    isAfterOperater = true;
                    operate = "÷";
                    break;


                    firstOperand = lblDisplay.Text; //////////////////////////////must use
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
                check = true;
            }
            string result = CalculateEngine.calculate(operate, firstOperand, secondOperand); ///*****************คำนวนน

            
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            
           
            isAfterEqual = true;
            if(check == true)
            {
                firstOperand = result;
            }
            
            
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
           /* if (isAfterEqual)
            {
                resetAll();
            }*/
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
                string result = CalculateEngine.calculate(operate, firstOperand, secondOperand); ///3232332323232323232
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
                    
                    double resul = Math.Round(1 / (Convert.ToDouble(lblDisplay.Text)), 7);
                    lblDisplay.Text = resul.ToString();
                    break;
                case "√":
                    double resu = Math.Sqrt(Convert.ToDouble(lblDisplay.Text));
                    int n1 = (Convert.ToInt32(lblDisplay.Text));
                    string text = n1.ToString();
                    resu = Math.Round(resu, 8-text.Length);
                    lblDisplay.Text = resu.ToString();
                    isAfterEqual = true;
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
