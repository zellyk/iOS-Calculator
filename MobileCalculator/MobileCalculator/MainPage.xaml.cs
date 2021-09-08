using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        private double num1;
        private double num2;
        private double result;
        private string numDisplay;
        private string operationSelected;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Buttons_Clicked(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text;

            switch (buttonText)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if(numDisplay != null)
                    {
                        numDisplay += buttonText;
                        numLabel.Text = numDisplay;
                    }
                    else
                    {
                        numDisplay = buttonText;
                        numLabel.Text = numDisplay;
                    }
                    break;
                case "+":
                case "-":
                case "*":
                case "÷":
                case "%":
                    if (!Double.TryParse(numDisplay, out num1))
                    {
                        numLabel.Text = "Couldn't parse the number, press AC";
                    }
                    else
                    {
                        num1 = Double.Parse(numDisplay);

                        numDisplay = "";
                        numLabel.Text = "0";

                        switch (buttonText)
                        {
                            case "+":
                                operationSelected = "Add";
                                break;
                            case "-":
                                operationSelected = "Subtract";
                                break;
                            case "*":
                                operationSelected = "Multiply";
                                break;
                            case "÷":
                                operationSelected = "Divide";
                                break;
                            case "%":
                                operationSelected = "Modular";
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "=":
                    if (!Double.TryParse(numDisplay, out num2))
                    {
                        numLabel.Text = "Couldn't parse the number, press AC";
                    }
                    else
                    {
                        num2 = Double.Parse(numDisplay);

                        switch (operationSelected)
                        {
                            case "Add":
                                result = num1 + num2;
                                numDisplay = result.ToString();
                                break;
                            case "Subtract":
                                result = num1 - num2;
                                numDisplay = result.ToString();
                                break;
                            case "Multiply":
                                result = num1 * num2;
                                numDisplay = result.ToString();
                                break;
                            case "Divide":
                                result = num1 / num2;
                                numDisplay = result.ToString();
                                break;
                            case "Modular":
                                result = num1 % num2;
                                numDisplay = result.ToString();
                                break;
                            default:
                                break;
                        }

                        numLabel.Text = numDisplay;

                        num1 = 0;
                        num2 = 0;
                        result = 0;
                        /*numDisplay = null;
                        operationSelected = null;*/
                    }
                    break;
                case "√":
                    if (!Double.TryParse(numDisplay, out num1))
                    {
                        numLabel.Text = "Couldn't parse the number, press AC";
                    }
                    else
                    {
                        num1 = Double.Parse(numDisplay);
                        result = Math.Sqrt(num1);

                        numDisplay = result.ToString();
                        numLabel.Text = numDisplay;

                        num1 = 0;
                        num2 = 0;
                        result = 0;
                        /*numDisplay = null;
                        operationSelected = null;*/
                    }
                    break;
                case "x2":
                    if (!Double.TryParse(numDisplay, out num1))
                    {
                        numLabel.Text = "Couldn't parse the number, press AC";
                    }
                    else
                    {
                        num1 = Double.Parse(numDisplay);
                        result = num1 * 2;

                        numDisplay = result.ToString();
                        numLabel.Text = numDisplay;

                        num1 = 0;
                        num2 = 0;
                        result = 0;
                        /*numDisplay = null;
                        operationSelected = null;*/
                    }
                    break;
                case "AC":
                    num1 = 0;
                    num2 = 0;
                    result = 0;
                    numDisplay = null;
                    operationSelected = null;
                    numLabel.Text = "0";
                    break;
                default:
                    break;
            }
        }
    }
}
