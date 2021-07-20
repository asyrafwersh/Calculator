using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// By : Asyraf Azahar
    public partial class CalculatorWindow : Page
    {
        string temp = "";
        string tempOperation = "";
        bool isOperation = false;
        bool OperationLock = false;
        bool isEqual = false;
        ResultsWindow resultsWindow;
        ClearDialog ClearDialog;
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        public CalculatorWindow(object user)
        {
            InitializeComponent();
            usernameTxt.Text = (string)user;
            this.ShowsNavigationUI = false;
        }

        private void Calculate()
        {

            switch (tempOperation)
            {
                case "/":
                    if (double.Parse(CalculatorTxtBox.Text) != 0 && double.Parse(temp) != 0)
                        CalculatorTxtBox.Text = (double.Parse(temp) / double.Parse(CalculatorTxtBox.Text)).ToString();
                    else
                    {
                        CalculatorTxtBox.Text = "0";
                    }

                    break;
                case "-":
                    CalculatorTxtBox.Text = (double.Parse(temp) - double.Parse(CalculatorTxtBox.Text)).ToString();

                    break;
                case "+":
                    CalculatorTxtBox.Text = (double.Parse(temp) + double.Parse(CalculatorTxtBox.Text)).ToString();

                    break;
                case "*":
                    CalculatorTxtBox.Text = (double.Parse(temp) * double.Parse(CalculatorTxtBox.Text)).ToString();

                    break;
                default:
                    break;
            }

            if (isOperation == true && OperationLock == true && isEqual == false)
            {
                temp = CalculatorTxtBox.Text;
                CalculatorTxtBox.Text = tempOperation;
            }

            if (isEqual == true)
            {
                isOperation = false;
                isEqual = false;
            }
        }

        private void numberButton(object sender)
        {
            if (isOperation == false)
            {
                if (CalculatorTxtBox.Text.Equals("0"))
                {
                    CalculatorTxtBox.Text = ((Button)sender).Content.ToString();
                }
                else { CalculatorTxtBox.Text += ((Button)sender).Content.ToString(); }
            }
            else
            {
                if (OperationLock)
                {
                    CalculatorTxtBox.Text = ((Button)sender).Content.ToString();
                    OperationLock = false;
                }
                else
                {
                    CalculatorTxtBox.Text += ((Button)sender).Content.ToString();
                }
            }
        }

        private void operationButton(object sender)
        {
            if (!((Button)sender).Content.ToString().Equals("="))
            {
                isEqual = false;
            }
            if (isOperation == false && isEqual == false)
            {
                temp = CalculatorTxtBox.Text;
                CalculatorTxtBox.Text = ((Button)sender).Content.ToString();
                tempOperation = ((Button)sender).Content.ToString();
                isOperation = true;
                OperationLock = true;
            }
            else if (isOperation == true && OperationLock == false)
            {
                OperationLock = true;
                Calculate();
            }
            else if (isOperation == true && OperationLock == true)
            {
                Calculate();
            }
        }

        private void Click_7(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }


        private void Click_4(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }


        private void Click_1(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_0(object sender, RoutedEventArgs e)
        {
            numberButton(sender);
        }

        private void Click_Plus(object sender, RoutedEventArgs e)
        {
            operationButton(sender);
        }


        private void Click_Minus(object sender, RoutedEventArgs e)
        {
            operationButton(sender);
        }


        private void Click_Multiplier(object sender, RoutedEventArgs e)
        {
            operationButton(sender);
        }

        private void Click_Divide(object sender, RoutedEventArgs e)
        {
            operationButton(sender);
        }

        private void Click_Equal(object sender, RoutedEventArgs e)
        {
            OperationLock = false;
            isEqual = true;
            operationButton(sender);
        }

        private void Click_Dot(object sender, RoutedEventArgs e)
        {
            if (isOperation == false)
            {
                if (!CalculatorTxtBox.Text.Contains('.'))
                {
                    CalculatorTxtBox.Text += ".";
                }
            }
            else if (isOperation == true && OperationLock == false)
            {
                if (!CalculatorTxtBox.Text.Contains('.'))
                {
                    CalculatorTxtBox.Text += ".";
                }
            }

        }

        private void CalculatorTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CalculatorTxtBox.Text.Length == 0)
            {
                CalculatorTxtBox.Text = "0";
            }

            if(errorTxtBox!=null)
                errorTxtBox.Visibility = Visibility.Collapsed;
        }

        private void Click_Backspace(object sender, RoutedEventArgs e)
        {

            if (CalculatorTxtBox.Text.Equals("0"))
            {
            }
            else { CalculatorTxtBox.Text = CalculatorTxtBox.Text.Remove(CalculatorTxtBox.Text.Length - 1, 1); }
            errorTxtBox.Visibility = Visibility.Collapsed;
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            CalculatorTxtBox.Text = "0";
            isOperation = false;
            OperationLock = false;
            temp = "";
            tempOperation = "";
            errorTxtBox.Visibility = Visibility.Collapsed;
        }

        private void Click_LoginPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Click_SaveResult(object sender, RoutedEventArgs e)
        {
            if (!CalculatorTxtBox.Text.Equals("0"))
            {
                try {
                    using (AppDbContext appDbContext = new AppDbContext())
                    {
                        var user = appDbContext.Users
                                .FirstOrDefault(s => s.username.Equals(usernameTxt.Text));
                        User user2 = user;

                        Data data = new Data();
                        data.Id = Guid.NewGuid();
                        data.CreatedDate = DateTime.Now;
                        data.result = CalculatorTxtBox.Text;
                        data.usernameID = user2.Id;

                        appDbContext.Add(data);
                        appDbContext.SaveChanges();

                        errorTxtBox.Visibility = Visibility.Visible;
                        errorTxtBox.Text = "Your result has been successfully saved.";
                    }
                }
                catch
                {
                    errorTxtBox.Visibility = Visibility.Visible;
                    errorTxtBox.Text = "Unknown Error saving your result. Please try again";
                }
            }
            else
            {
                errorTxtBox.Visibility = Visibility.Visible;
                errorTxtBox.Text = "Error saving your result (0 result). Please try again";
            }
        }

        private void Click_GetResult(object sender, RoutedEventArgs e)
        {
            resultsWindow = new ResultsWindow(usernameTxt.Text);
            resultsWindow.Closed += OnGetResultDialogClosing;
            resultsWindow.ShowDialog();
        }

        public void OnGetResultDialogClosing(object sender, System.EventArgs e)
        {
            errorTxtBox.Visibility = Visibility.Collapsed;
            if (GlobalVar.resultDialog)
            {
                try
                {
                    using (AppDbContext appDbContext = new AppDbContext())
                    {
                        var data = appDbContext.Datas
                                .FirstOrDefault(s => s.Id==GlobalVar.Id);

                        Button tempbutton = new Button();
                        tempbutton.Content = data.result;
                        CalculatorTxtBox.Text = "0";
                        numberButton(tempbutton);
                        GlobalVar.resultDialog = false;
                    }

                }
                catch
                {
                    errorTxtBox.Visibility = Visibility.Visible;
                    errorTxtBox.Text = "Error retrieving your data. Please try again";
                }
            }
        }

        private void Click_ClearResult(object sender, RoutedEventArgs e)
        {
            ClearDialog = new ClearDialog(usernameTxt.Text);
            ClearDialog.Closed += OnClearResultDialogClosing;
            ClearDialog.ShowDialog();
        }

        public void OnClearResultDialogClosing(object sender, System.EventArgs e)
        {
            if (GlobalVar.isNo == false)
            {
                errorTxtBox.Visibility = Visibility.Visible;
                errorTxtBox.Text = "Your data has been cleared.";
            }
        }
    }
}
