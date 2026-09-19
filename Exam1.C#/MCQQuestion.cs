using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public class MCQQuestion : Question
    {
        public MCQQuestion() : base() { }

        public MCQQuestion(string header, string body, double mark, Answer[] answers)
            : base(header, body, mark)
        {
            AnswerList = answers;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} \t Mark: {Mark}");
            Console.WriteLine(Body);
            if (AnswerList != null)
            {
                foreach (var ans in AnswerList)
                {
                    Console.WriteLine(ans);
                }
            }
            Console.WriteLine("----------------------------------");
        }

        public override object Clone()
        {
            Answer[] clonedAnswers = new Answer[this.AnswerList?.Length ?? 0];
            if (this.AnswerList != null)
            {
                for (int i = 0; i < this.AnswerList.Length; i++)
                {
                    clonedAnswers[i] = (Answer)this.AnswerList[i].Clone();
                }
            }

            return new MCQQuestion(this.Header, this.Body, this.Mark, clonedAnswers)
            {
                RightAnswer = (Answer?)this.RightAnswer?.Clone()
            };
        }
    }
}
