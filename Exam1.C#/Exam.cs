using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public abstract class Exam : ICloneable
    {
        public int Time { get; set; } 
        public int NumberOfQuestions { get; set; } 
        public Question[]? ListOfQuestions { get; set; } 

        public Exam() : this(0, 0) { }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }
        public abstract void ShowExam();

        public abstract object Clone();
    }
}
