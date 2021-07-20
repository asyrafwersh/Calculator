using Calculator.Classes;
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

namespace Calculator
{
    /// By : Asyraf Azahar
    public partial class UserDialog : Window
    {
        public UserDialog()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (registerTxtBox.Text.Length >= 3 && registerTxtBox.Text.Length <= 20)
                {
                    using (AppDbContext appDbContext = new AppDbContext())
                    {
                        var user = appDbContext.Users
                            .FirstOrDefault(s => s.username.Equals(registerTxtBox.Text));

                        if (user != null)
                        {
                            registerErrorTxtBox.Visibility = Visibility.Visible;
                            registerErrorTxtBox.Text = "username already exist.\nPlease try again.";
                        }
                        else
                        {
                            User user2 = new User();
                            user2.Id = Guid.NewGuid();
                            user2.username = registerTxtBox.Text;
                            user2.CreatedDate = DateTime.Now;

                            appDbContext.Add(user2);
                            appDbContext.SaveChanges();

                            registerTxtBox.Text = "";
                            this.Close();
                        }
                        
                    }
                }
                else if (registerTxtBox.Text.Length < 3)
                {
                    registerErrorTxtBox.Visibility = Visibility.Visible;
                    registerErrorTxtBox.Text = "Please enter a username\nmore than 3 characters";
                }
                else if (registerTxtBox.Text.Length > 20)
                {
                    registerErrorTxtBox.Visibility = Visibility.Visible;
                    registerErrorTxtBox.Text = "Please enter a username\nless than 20 characters";
                }
            }
            catch(Exception ex)
            {
                registerErrorTxtBox.Visibility = Visibility.Visible;
                registerErrorTxtBox.Text = "username already exist.\nPlease try again.";
            }
        }
    }
}
