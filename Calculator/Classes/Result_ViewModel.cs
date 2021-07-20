using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Calculator.Classes
{
    public class Result_ViewModel
    {

        private ObservableCollection<Data> datalist;
        public ObservableCollection<Data> DataList
        {
            get { return datalist; }
            set { datalist = value; }
        }

        public Result_ViewModel(string username)
        {
            try
            {
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    var user = appDbContext.Users
                                .First(s => s.username.Equals(username));

                    var datasList = appDbContext.Datas
                        .Where(s => s.usernameID.Equals(user.Id)).ToList();
                    datalist = new ObservableCollection<Data>(datasList);
                }
            }
            catch { }
        }
    }
}
