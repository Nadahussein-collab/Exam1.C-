using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.C_
{
    public class Subject : ICloneable
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? SubjectExam { get; set; } 

        public Subject() : this(0, "Undefined Subject") { }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam()
        {
            int examType, time, numQuestions;

            do
            {
                Console.Write("Please Enter Type Of Exam You Want To Create (1 for Practical and 2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            do
            {
                Console.Write("Please Enter The Time For Exam In Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);

            do
            {
                Console.Write("Please Enter The Number Of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0);

            Console.Clear();

            if (examType == 1)
            {
                SubjectExam = new PracticalExam(time, numQuestions);
            }
            else
            {
                SubjectExam = new FinalExam(time, numQuestions);
            }

            SubjectExam.ListOfQuestions = new Question[numQuestions];

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"\n--- Creating Question {i + 1} ---");

                int qType = 1;

                if (examType == 2)
                {
                    do
                    {
                        Console.Write("Please Choose Question Type (1 for True OR False || 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2));
                }
                else
                {
                    qType = 2; 
                }

                Console.Write("Please Enter Question Header: ");
                string header = Console.ReadLine() ?? $"Question {i + 1}";

                Console.Write("Please Enter Question Body: ");
                string body = Console.ReadLine() ?? "";

                double mark;
                do
                {
                    Console.Write("Please Enter Question Mark: ");
                } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                if (qType == 1)
                {
                    var tfQuestion = new TrueFalseQuestion(header, body, mark);

                    int rightAns;
                    do
                    {
                        Console.Write("Please Enter Right Answer Id (1 for True || 2 for False): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAns) || (rightAns != 1 && rightAns != 2));

                    tfQuestion.RightAnswer = tfQuestion.AnswerList?[rightAns - 1];
                    SubjectExam.ListOfQuestions[i] = tfQuestion;
                }
                else
                {
                    Answer[] choices = new Answer[3];
                    Console.WriteLine("Enter 3 Choices for MCQ:");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"Please Enter Choice Number {j + 1}: ");
                        string choiceText = Console.ReadLine() ?? "";
                        choices[j] = new Answer(j + 1, choiceText);
                    }

                    var mcqQuestion = new MCQQuestion(header, body, mark, choices);

                    int rightAns;
                    do
                    {
                        Console.Write("Please Enter Right Answer Id (1, 2, or 3): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAns) || rightAns < 1 || rightAns > 3);

                    mcqQuestion.RightAnswer = choices[rightAns - 1];
                    SubjectExam.ListOfQuestions[i] = mcqQuestion;
                }
                Console.Clear();
            }
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }

        public object Clone()
        {
            return new Subject(this.SubjectId, this.SubjectName);
        }
    }
}
