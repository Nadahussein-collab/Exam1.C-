using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public class FinalExam : Exam
    {
        public FinalExam() : base() { }

        public FinalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("================ Final Exam ================\n");

            if (ListOfQuestions == null) return;

            double totalMarks = 0;
            double userGrade = 0;

            int[] userAnswers = new int[ListOfQuestions.Length];

            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                var q = ListOfQuestions[i];
                totalMarks += q.Mark;

                q.DisplayQuestion();

                Console.Write("Enter your answer Id: ");
                int.TryParse(Console.ReadLine(), out userAnswers[i]);

                if (q.RightAnswer != null && userAnswers[i] == q.RightAnswer.AnswerId)
                {
                    userGrade += q.Mark;
                }

                Console.WriteLine("\n----------------------------------\n");
            }

            Console.Clear();
            Console.WriteLine("================ Exam Questions and Answers ================");

            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                var q = ListOfQuestions[i];
                Console.WriteLine($"Q{i + 1}) {q.Body}");
                Console.WriteLine($"Your Answer Id: {userAnswers[i]}");
                Console.WriteLine($"Right Answer: {q.RightAnswer?.AnswerText}");
                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine($"\nYour Total Grade: {userGrade} / {totalMarks}");
        }

        public override object Clone()
        {
            return new FinalExam(this.Time, this.NumberOfQuestions);
        }
    }
}
