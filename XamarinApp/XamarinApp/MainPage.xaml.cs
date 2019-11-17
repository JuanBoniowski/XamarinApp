using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.DAL;
using XamarinApp.Models;

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

            UserModel user = new UserModel();
            user.UserName = txtUserName.Text;
            user.Pasword = txtPassword.Text;

            bool Isvalid = Validation(user);
          
            if (Isvalid)
            {
              Task<bool> returnResults  =   UserRepository.IsAuthorized(user);

                if (returnResults.Result)
                {
                    string msg = string.Format("Your username is '{0}' and your password is '{1}'", txtUserName.Text, txtPassword.Text);
                    DisplayAlert("Demo App", msg, "Ok");
                }
                else
                {
                    lblValidation.Text = "Your are not able to access"; 
                }

            }
            else
            {
                lblValidation.Text = "Please input proper Username and Password"; 
            }

            UserRepository.GetAll(); 
        }

        private bool Validation(UserModel user)
        {
            if (user.UserName ==null)
            {
                return false; 
            }
            else if (user.Pasword == null)
            {
                return false; 
            }
            return true; 
        }

        private void btnAddUser_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel() {UserName="Steve", Pasword="2345"};

            UserRepository.AddUser(user);

            DisplayAlert("Confirmation", "You added a user", "OK"); 


        }

        private void btnDeleteuser_Clicked(object sender, EventArgs e)
        {

            UserModel user = new UserModel() {UserName="Steve", Pasword="2345" }; 
            UserRepository.DeleteUser(user); 
        }
    }
}
