using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public abstract class Question : IComparable<Question>, ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[]? AnswerList { get; set; }
        public Answer? RightAnswer { get; set; }

        public Question() : this("General Question", "No Body", 0) { }

        public Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        public abstract void DisplayQuestion();

        public override string ToString()
        {
            return $"[{Header}] (Mark: {Mark})\n{Body}";
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return this.Mark.CompareTo(other.Mark);
        }

        public abstract object Clone();
    }
}
