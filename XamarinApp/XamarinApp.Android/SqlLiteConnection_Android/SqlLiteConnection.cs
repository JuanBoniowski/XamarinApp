using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using XamarinApp.Interface;
using System.IO;
using XamarinApp.Droid.SqlLiteConnection_Android;

[assembly:Xamarin.Forms.Dependency(typeof(SqlLiteConnection))]
namespace XamarinApp.Droid.SqlLiteConnection_Android
{
    public class SqlLiteConnection : IsqlLite
    {
        public SQLiteConnection GetConnection()
        {
            //databaseName
            string SqlLiteDBName = "DBXamarinAppDemo.db3";
            //database path
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //combine
            var path = Path.Combine(documentPath, SqlLiteDBName);

            //return of sqllitconnection
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn; 
        }
    }
}