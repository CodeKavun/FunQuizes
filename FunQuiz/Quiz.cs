using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunQuiz
{
    internal class Quiz
    {
        public string Title { get; set; }
        public List<Quest> Questions { get; private set; }
        public List<User> TopPlayers { get; private set; }

        public Quiz(string title)
        {
            Title = title;
            Questions = new List<Quest>();
            TopPlayers = new List<User>();
        }

        public void QuizLoop()
        {
            foreach (Quest quest in Questions) quest.AnswerQuest();

            if (!UserManager.CurrentUser.CompletedQuizes.ContainsKey(Title))
                UserManager.CurrentUser.CompletedQuizes.Add(Title, 1);
            UserManager.SaveData();

            TopPlayers.Add(UserManager.CurrentUser);
            ShowTop();
        }

        public void JesusLoop()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("\t[0] Show");
                Console.WriteLine("\t[1] Add question");
                Console.WriteLine("\t[2] Remove question");
                Console.WriteLine("\t[3] Edit question");
                Console.WriteLine("\t[4] Top Players");

                Console.Write("Enter the command (any other - exit): ");
                int operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 0:
                        Console.WriteLine(this);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 1:
                        AddQuestions();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(this + "\n");
                        RemoveQuestion();
                        break;
                    case 3:
                        Console.WriteLine(this + "\n");
                        Console.Write("What quastion you want to edit: ");
                        int quastionIndex = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Questions[quastionIndex].JesusLoop();
                        break;
                    case 4:
                        ShowTop();
                        break;
                    default:
                        return;
                }
            }
        }

        public void AddQuestions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(this + "\n");

                Console.Write("Enter the question (^ for exit): ");
                string title = Console.ReadLine();
                if (title == "^") break;

                Questions.Add(new Quest(title));
            }
            Console.Clear();
        }

        public void RemoveQuestion()
        {
            Console.Write("Enter the index of question to remove: ");
            int answerIndex = int.Parse(Console.ReadLine());
            Questions.RemoveAt(answerIndex);
            Console.Clear();
        }

        public void ShowTop()
        {
            Console.WriteLine(" __ Top Players __ \n");

            int index = 1;
            foreach (User user in TopPlayers) Console.WriteLine($"{index}. {user.Name}\n");

            Console.ReadKey();
            Console.Clear();
        }

        public override string ToString()
        {
            string str = $" -= {Title} =-\n";
            int index = 0;
            foreach (Quest quest in Questions)
            {
                str += $"[{index}]" + quest;
                index++;
            }

            return str;
        }
    }
}
