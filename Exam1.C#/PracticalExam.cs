using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public class PracticalExam : Exam
    {
        public PracticalExam() : base() { }

        public PracticalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("================ Practical Exam ================\n");

            if (ListOfQuestions == null) return;

            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                var q = ListOfQuestions[i];
                q.DisplayQuestion();

                Console.Write("Enter your answer Id: ");
                _ = int.TryParse(Console.ReadLine(), out int userAnsId);
                Console.WriteLine("\n----------------------------------\n");
            }

            Console.Clear();
            Console.WriteLine("================ Exam Result (Right Answers) ================");

            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                var q = ListOfQuestions[i];
                Console.WriteLine($"Q{i + 1}) {q.Body}");
                Console.WriteLine($"Right Answer: {q.RightAnswer?.AnswerText}");
                Console.WriteLine("----------------------------------");
            }
        }

        public override object Clone()
        {
            return new PracticalExam(this.Time, this.NumberOfQuestions);
        }
    }
}
