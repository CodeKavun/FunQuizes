using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunQuiz
{
    internal static class UserManager
    {
        public static List<User> Users { get; set; }
        public static User CurrentUser { get; set; }

        public static void Init()
        {
            User superUser = new User("biedronka", "biedronka", UserType.JesusMode);
            Users = new List<User> { superUser };

            if (!File.Exists("Users.json")) SaveData();
            else LoadData();

            Console.WriteLine("  -= Welcome to our really Awful Quiz Time! =-\n\n");

            LoginRegister();
        }

        private static void LoginRegister()
        {
            while (true)
            {
                Console.Write("  0 - login; 1 - register: ");
                int userOperation = int.Parse(Console.ReadLine());

                switch (userOperation)
                {
                    case 0:
                        Console.Write("Enter your login: ");
                        string login = Console.ReadLine();
                        if (!UserFound(login))
                        {
                            Console.WriteLine($"User with '{login}' login does not exist!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        CurrentUser = Users.Where(user => user.Name == login).First();

                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();
                        if (password != CurrentUser.Password)
                        {
                            Console.WriteLine("Incorrect password");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        Console.WriteLine("You has been logged successfully!");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    default:
                        Console.Write("Imagine username: ");
                        string username = Console.ReadLine();
                        
                        Console.Write("Write a password: ");
                        string regPassword = Console.ReadLine();

                        Users.Add(new User(username, regPassword, UserType.Ordinar));
                        SaveData();

                        Console.WriteLine("You signed up successfully! Now login.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private static bool UserFound(string login)
        {
            foreach (User user in Users)
            {
                if (user.Name == login) return true;
            }
            return false;
        }

        public static void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("Users.json", false, Encoding.UTF8))
            {
                string data = JsonConvert.SerializeObject(Users, Formatting.Indented);
                writer.WriteLine(data);
            }
        }

        public static void LoadData()
        {
            using (StreamReader reader = new StreamReader("Users.json"))
            {
                string data = reader.ReadToEnd();
                Users = JsonConvert.DeserializeObject<List<User>>(data);
            }
        }
    }
}
