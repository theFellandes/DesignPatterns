using System;
using System.Collections.Generic;

namespace BTK_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            
            Teacher teacher = new Teacher(mediator) {Name = "Engin"};
            mediator.Teacher = teacher;

            
            Student student = new Student(mediator) {Name = "Derin"};
            Student student2 = new Student(mediator) {Name = "Salih"};
            mediator.Students = new List<Student>{student, student2};
            
            teacher.SendNewImageUrl("slide1.jpg");
            teacher.ReceiveQuestion("is it true?", student);
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    //Teacher ve Student bilgiyi doğrudan Mediator'e gönderiyor.
    //  Mediator da Teacher ya da Student'a yönlendiriyor.
    
    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0}, {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name, answer);
        }

    }

    class Student : CourseMember
    {
        public string Name { get; set; }
        
        public Student(Mediator mediator) : base(mediator)
        {
        }
        public void ReceiveImage(string url)
        {
            Console.WriteLine("Student {1} received image: {0}", url, Name);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student {1} received answer {0}", answer, Name);
        }

    }

    //Mediator iletişimi sağlanacak kişileri bilmesi gerekiyor.
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}