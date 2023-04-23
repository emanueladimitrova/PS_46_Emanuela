using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            LoginValidation lg = new LoginValidation(username, password, PrintErrorMsg);

            User user = null;
            if (lg.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.Username + ", " + user.Password + ", " + user.FakNum + ", " + user.Role);
            }

            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ADMIN:
                    AdminMenu();
                    break;
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("User is ANONYMOUS.");
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine("User is INSPECTOR.");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine("User is PROFESSOR.");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine("User is STUDENT.");
                    break;
            }
        }

        static void PrintErrorMsg(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        static void AdminMenu()
        {
            Console.WriteLine("User is ADMIN.");
            Console.WriteLine("Select an option: ");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Change user role");
            Console.WriteLine("2.Change user activity");
            Console.WriteLine("3. List users");
            Console.WriteLine("4. View activity log");
            Console.WriteLine("5. View current activity log");

            Console.Write("\nEnter your choice: ");
            int option = int.Parse(Console.ReadLine());
            string username;

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    username = Console.ReadLine();
                    Console.WriteLine("Enter new role: ");
                    int role = int.Parse(Console.ReadLine());
                    UserData.AssignUserRole(username, (UserRoles)role);
                    break;
                case 2:
                    username = Console.ReadLine();
                    Console.WriteLine("Enter new active date: ");
                    DateTime activeDate = DateTime.Parse(Console.ReadLine());
         
                    UserData.SetUserActiveTo(username, activeDate);
                    break;
                case 3:
                    break;
                case 4:
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> allActs = Logger.GetAllActivities();

                    foreach (string line in allActs)
                    {
                        sb.Append(line);
                    }

                    Console.WriteLine(sb.ToString());

                    break;
                case 5:
                    sb = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.getCurrentSessionActivities("admin");

                    foreach(string line in currentActs)
                    {
                        sb.Append(line);
                    }

                    Console.WriteLine(sb.ToString());
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
