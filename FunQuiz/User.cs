using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunQuiz
{
    enum UserType
    {
        Ordinar,
        JesusMode
    }

    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public List<Quiz> CompletedQuizes { get; set; }

        public User(string name, string password, UserType type)
        {
            Name = name;
            Password = password;
            Type = type;
        }
    }
}
