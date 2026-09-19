using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : base()
        {
            AnswerList = new Answer[]
            {
                new Answer(1,"True"),
                new Answer(2,"False")
            };
        }
        public TrueFalseQuestion(string header, string body, double mark) : base(header, body, mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
        }
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\t Mark: {Mark}");
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
            return new TrueFalseQuestion(this.Header, this.Body, this.Mark)
            {
                RightAnswer = (Answer?)this.RightAnswer?.Clone()
            };
        }
    }
}
