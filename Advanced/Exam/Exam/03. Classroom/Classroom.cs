using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity == this.Count)
            {
                return "No seats in the classroom";
            }
            else
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            int index = FindStudent(firstName, lastName);

            if (index == -1)
            {
                return "Student not found";
            }
            else
            {
                this.students.RemoveAt(index);
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Subject == subject)
                {
                    result.Add(this.students[i]);
                }
            }

            if (result.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}")
                    .AppendLine("Students:");

                foreach (var student in result)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            int index = FindStudent(firstName, lastName);

            Student student = null;
            if (index != -1)
            {
                student = this.students[index];
            }

            return student;
        }

        private int FindStudent(string firstName, string lastName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Student student = this.students[i];

                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
