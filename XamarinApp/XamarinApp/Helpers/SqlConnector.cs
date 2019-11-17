using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Interface;
using XamarinApp.Models;

namespace XamarinApp.Helpers
{
    public static class SqlConnector
    {
        public static SQLiteConnection GetConnection()
        {
            var connection = DependencyService.Get<IsqlLite>().GetConnection();
            connection.CreateTable<UserModel>();
            return connection; 
        }
    }
}
