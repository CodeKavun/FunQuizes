using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User superUser = new User("biedronka", "biedronka", UserType.JesusMode);

            List<User> users = new List<User> { superUser };

            Console.WriteLine("  -= Welcome to our really Awful Quiz Time! =-\n\n");

            Console.Write("Enter your login: ");
            string login = Console.ReadLine();
            if (!UserFound(users, login))
            {
                Console.WriteLine($"User with '{login}' login does not exist!");
                return;
            }

            User currentUser = users.Where(user => user.Name == login).First();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (password != currentUser.Password)
            {
                Console.WriteLine("Incorrect password");
                return;
            }

            JesusModePanel panel = new JesusModePanel(users);

            if (currentUser.Type == UserType.JesusMode) panel.PanelLoop();

            Console.ReadKey();
        }

        private static bool UserFound(List<User> users, string username)
        {
            foreach (User user in users)
            {
                if (user.Name == username) return true;
            }
            return false;
        }
    }
}
