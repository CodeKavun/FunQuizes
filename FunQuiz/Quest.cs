using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunQuiz
{
    internal class Quest
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public bool AnsweredCorrectly { get; set; } = false;

        public Quest(string text)
        {
            Text = text;
            Answers = new List<Answer>();
        }

        public void AnswerQuest()
        {
            Console.WriteLine(this + "\n");
            Console.Write("Enter your answer variant: ");
            int answerIndex = int.Parse(Console.ReadLine());

            AnsweredCorrectly = Answers[answerIndex].IsCorrect;

            Console.WriteLine(AnsweredCorrectly ? "Awesome!" : "Error!");
            Console.WriteLine("\n====Press any key to procced to the next question====");
            Console.ReadKey();
            Console.Clear();
        }

        public void JesusLoop()
        {
            while (true)
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("\t[0] Show");
                Console.WriteLine("\t[1] Add Answer");
                Console.WriteLine("\t[2] Remove Answer\n");

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
                        AddAnswers();
                        break;
                    case 2:
                        RemoveAnswer();
                        break;
                    default:
                        return;
                }
            }
        }

        public void AddAnswers()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(this + "\n");

                Console.Write("Enter the the answer of quastion (^ for exit): ");
                string answerText = Console.ReadLine();
                if (answerText == "^") break;

                Console.Write("Is it correct answer of quastion (0 - false, anothers - true): ");
                bool isCorrect = Convert.ToBoolean(int.Parse(Console.ReadLine()));

                Answers.Add(new Answer(answerText, isCorrect));
            }
            Console.Clear();
        }

        public void RemoveAnswer()
        {
            Console.Write("Enter the index of answer to remove: ");
            int answerIndex = int.Parse(Console.ReadLine());
            Answers.RemoveAt(answerIndex);
            Console.Clear();
        }

        public override string ToString()
        {
            string str = Text + "\n";

            int index = 0;
            foreach (Answer answer in Answers)
            {
                str += $"\t[{index}] {answer.Text}\n";
                index++;
            }

            return str;
        }
    }
}
