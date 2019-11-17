using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Helpers;
using XamarinApp.Models;

namespace XamarinApp.DAL
{
    public static class UserRepository
    {
        public static Task<List<UserModel>> GetAll()
        {
            List<UserModel> lstOfUsers = null;

            using (var _connection = SqlConnector.GetConnection())
            {
                lstOfUsers = _connection.Table<UserModel>().ToList(); 
            }

            return Task.FromResult(lstOfUsers); 
        }

        public static Task<bool> AddUser(UserModel user)
        {
            using (var _connection = SqlConnector.GetConnection())
            {
                _connection.Insert(user); 
            }

            return Task.FromResult(true); 
        }
        //Validation

        public static Task<bool> IsAuthorized(UserModel user)
        {
            bool isAuthorized = false;
            string userName = user.UserName;
            string password = user.Pasword;

            using (var _connection = SqlConnector.GetConnection())
            {
                int returnValue = _connection.Table<UserModel>().Where(userVar => userVar.UserName == userName && userVar.Pasword == password).Count();

                if (returnValue>0)
                {
                    isAuthorized = true; 
                }
            }

            return Task.FromResult(isAuthorized); 
        }

        //delete
        public static Task<bool> DeleteUser(UserModel user)
        {
            string userName = user.UserName;
            string password = user.Pasword; 

            using (var _connection = SqlConnector.GetConnection())
            {
                _connection.Table<UserModel>().Delete(userVar => userVar.UserName==userName && userVar.Pasword==password); 
            }

            return Task.FromResult(true); 
        }
    }
}
