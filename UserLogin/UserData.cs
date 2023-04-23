using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;
        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                User user = new User();
                user.Username = "admin";
                user.Password = "admin";
                user.FakNum = "121220042";
                user.Role = 1;
                user.Created = DateTime.Now;
                user.ActiveUntil = DateTime.MaxValue;
                _testUsers.Add(user);

                user = new User();
                user.Username = "emmmaa";
                user.Password = "asdasda";
                user.FakNum = "121220042";
                user.Role = 4;
                user.Created = DateTime.Now;
                user.ActiveUntil = DateTime.MaxValue;
                _testUsers.Add(user);

                user = new User();
                user.Username = "oooooo";
                user.Password = "dasdasdas";
                user.FakNum = "121220042";
                user.Role = 4;
                user.Created = DateTime.Now;
                user.ActiveUntil = DateTime.MaxValue;
                _testUsers.Add(user);
            }
        }

        static public User IsUserPassCorrect(string username, string password)
        {
            return (from user in TestUsers
                    where (user.Username.Equals(username) && user.Password.Equals(password))
                    select user).First();

            /*
            foreach(User currUser in TestUsers)
            {
                if(currUser.Username.Equals(username) && currUser.Password.Equals(password))
                {
                    return currUser;
                }
            }

            return null;
            */
        }

        static public void SetUserActiveTo(string username, DateTime activeUntil)
        {
            for(int i = 0; i < TestUsers.Count; i++)
            {
                if (TestUsers[i].Username.Equals(username))
                {
                    TestUsers[i].ActiveUntil = activeUntil;
                    Logger.LogActivity("Changed active period of user " + username);
                }
            }
        }

        static public void AssignUserRole(string username, UserRoles role)
        {
            for (int i = 0; i < TestUsers.Count; i++)
            {
                if (TestUsers[i].Username.Equals(username))
                {
                    TestUsers[i].Role = (Int32)role;
                    Logger.LogActivity("Changed role of user " + username);
                }
            }
        }

        static public bool checkIfPresentUsers()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;

            int count = queryUsers.Count();

            return count == 0 ? true : false;
        }
        static public void copyTestUsers()
        {
            UserContext context = new UserContext();

            foreach (User user in TestUsers)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
