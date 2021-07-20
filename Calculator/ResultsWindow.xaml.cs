using Calculator.Classes;
using System;
using System.Collections.Generic;
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
    public partial class ResultsWindow : Window
    {
        public string username;
        public ResultsWindow(string user)
        {
            InitializeComponent();
            username = user;
            try
            {
                Result_ViewModel result_ViewModel = new Result_ViewModel(username);
                ResultDataGrid.ItemsSource = result_ViewModel.DataList;
            }
            catch { }
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_GetResult(object sender, RoutedEventArgs e)
        {
            GlobalVar.Id = ((Guid)((Button)sender).Tag);
            GlobalVar.resultDialog = true;
            this.Close();
        }
    }
}
