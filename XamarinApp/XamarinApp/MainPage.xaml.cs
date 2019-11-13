using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            string msg = string.Format("Your username is '{0}' and your password is '{1}'", txtUserName.Text, txtPassword.Text); 
            DisplayAlert("Demo App", msg, "Ok"); 
        }
    }
}
