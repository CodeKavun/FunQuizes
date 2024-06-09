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
            UserManager.Init();

            JesusModePanel panel = new JesusModePanel();
            if (UserManager.CurrentUser.Type == UserType.JesusMode) panel.PanelLoop();
            else
            {
                while (true)
                {
                    Console.WriteLine(panel + "\n");

                    Console.Write("Select quiz: ");
                    int quizIndex = int.Parse(Console.ReadLine());

                    Console.Clear();
                    panel.Quizzes[quizIndex].QuizLoop();
                }
            }

            Console.ReadKey();
        }
    }
}
