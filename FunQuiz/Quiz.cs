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
        public List<Quest> Questions { get; set; }

        public Quiz(string title)
        {
            Title = title;
            Questions = new List<Quest>();
        }

        public void QuizLoop()
        {
            foreach (Quest quest in Questions) quest.AnswerQuest();
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

                Console.Write("Enter the command: ");
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
