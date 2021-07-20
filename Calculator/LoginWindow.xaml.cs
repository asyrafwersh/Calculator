using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Calculator
{
    /// By : Asyraf Azahar
    public partial class LoginWindow : Page
    {
        UserDialog userDialog = new UserDialog();
        public LoginWindow()
        {
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (usernameTxtBox.Text.Length >= 3 && usernameTxtBox.Text.Length <= 20)
                {
                    using (AppDbContext appDbContext = new AppDbContext())
                    {
                        var user = appDbContext.Users
                            .First(s => s.username.Equals(usernameTxtBox.Text));

                        if (user != null)
                        {
                            loginErrorTxtBox.Visibility = Visibility.Hidden;
                            loginErrorTxtBox.Text = "";
                            this.NavigationService.Navigate(new CalculatorWindow(user.username));
                        }
                        else
                        {
                            userDialog = new UserDialog();
                            userDialog.Closed += OnUserDialogClosing;
                            userDialog.ShowDialog();
                        }
                    }
                }
                else if(usernameTxtBox.Text.Length < 3)
                {
                    loginErrorTxtBox.Visibility = Visibility.Visible;
                    loginErrorTxtBox.Text = "Please enter a username\nmore than 3 characters";
                }
                else if (usernameTxtBox.Text.Length > 20)
                {
                    loginErrorTxtBox.Visibility = Visibility.Visible;
                    loginErrorTxtBox.Text = "Please enter a username\nless than 20 characters";
                }

            }
            catch (Exception ex)
            {
                userDialog = new UserDialog();
                userDialog.Closed += OnUserDialogClosing;
                userDialog.ShowDialog();
            }
        }

        public void OnUserDialogClosing(object sender, System.EventArgs e)
        {
            usernameTxtBox.Text = "";
            loginErrorTxtBox.Visibility = Visibility.Hidden;
        }

    }
}
