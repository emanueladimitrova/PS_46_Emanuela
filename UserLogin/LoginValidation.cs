using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class LoginValidation
    {

        string _username;
        string _password;
        string _error_msg;

        public static UserRoles currentUserRole
        {
            get; private set;
        }

        public static string currentUserUsername { get; private set; }

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError _actionOnError;


        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            _username = username;
            _password = password;
            _actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            Boolean emptyUserName, emptyPassword;
            emptyUserName = _username.Equals(String.Empty);
            emptyPassword = _password.Equals(String.Empty);

            if (emptyUserName)
            {
                _error_msg = "Username is empty!";
            }
            if(emptyPassword)
            {
                _error_msg = "Password is empty!";
            }

            if(_username.Length < 5)
            {
                _error_msg = "Username cannot be less than 5 characters!";
            }

            User retUser = UserData.IsUserPassCorrect(_username, _password);
            if (retUser == null)
            {
                _error_msg = "Username/pass not found in test users!";
            }

            if (_error_msg != null)
            {
                _actionOnError(_error_msg);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = retUser;
            currentUserRole = (UserRoles)user.Role;
            currentUserUsername = user.Username;

            Logger.LogActivity("Successfull login");
            return true;
        }
    }
}
