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
    public partial class ClearDialog : Window
    {
        private string username;
        public ClearDialog(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private async void Yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    var user = appDbContext.Users
                        .FirstOrDefault(s => s.username.Equals(username));

                    var datasList = appDbContext.Datas
                        .Where(s => s.usernameID.Equals(user.Id)).ToList();

                    foreach (Data datas in datasList)
                    {
                        appDbContext.Datas.Remove(datas);
                        await appDbContext.SaveChangesAsync();
                    }
                }

                GlobalVar.isNo = false;
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            GlobalVar.isNo = true;
            this.Close();
        }
    }
}
