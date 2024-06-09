using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FunQuiz
{
    internal class JesusModePanel
    {
        public List<Quiz> Quizzes { get; private set; }

        public JesusModePanel()
        {
            Quizzes = new List<Quiz>();

            if (!File.Exists("Quiz.json")) Save();
            else Load();
        }

        public void PanelLoop()
        {
            while (true)
            {
                Console.WriteLine("  -= JESUS MODE =-\n\n");

                Console.WriteLine("Commands (enter other number for exit): ");
                Console.WriteLine("\t[0] Add quiz");
                Console.WriteLine("\t[1] Remove quiz");
                Console.WriteLine("\t[2] Edit quiz");
                Console.WriteLine("\t[3] Show");
                Console.WriteLine("\t[4] Save");

                Console.Write("Select command: ");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 0:
                        AddQuiz();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine(this + "\n");
                        RemoveQuiz();
                        break;
                    case 2:
                        Console.WriteLine(this + "\n");
                        Console.Write("Enter the index of quiz to edit: ");
                        int quizIndex = int.Parse(Console.ReadLine());
                        Quizzes[quizIndex].JesusLoop();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine(this + "\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Save();
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }
        }

        private void AddQuiz()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(this + "\n");

                Console.Write("Enter the quiz (^ for exit): ");
                string title = Console.ReadLine();
                if (title == "^") break;

                Quizzes.Add(new Quiz(title));
            }
            Console.Clear();
        }

        private void RemoveQuiz()
        {
            Console.Write("Enter the index of quiz to remove: ");
            int answerIndex = int.Parse(Console.ReadLine());
            Quizzes.RemoveAt(answerIndex);
            Console.Clear();
        }

        private void Save()
        {
            using (StreamWriter writer = new StreamWriter("Quiz.json", false, Encoding.UTF8))
            {
                string data = JsonConvert.SerializeObject(Quizzes, Formatting.Indented);
                writer.WriteLine(data);
            }

            Console.WriteLine("\nSaved!");
            Console.ReadKey();
        }

        private void Load()
        {
            using (StreamReader reader = new StreamReader("Quiz.json"))
            {
                string data = reader.ReadToEnd();
                Quizzes = JsonConvert.DeserializeObject<List<Quiz>>(data);
            }
        }

        public override string ToString()
        {
            string str = string.Empty;
            int index = 0;
            foreach (Quiz quiz in Quizzes)
            {
                str += $"[{index}] {quiz.Title} - {quiz.Questions.Count} quastions\n";
                index++;
            }

            return str;
        }
    }
}
