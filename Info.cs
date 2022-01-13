using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Info
    {
        public void display(Student student)  
        {

        // Console.WriteLine(student); 
        Console.WriteLine("StudentId:" + student.Id + "\tStudentName:" + student.Name +"\t StudentCourseType"+student.ParticularCourseType+ "\t StudentDoB:" + student.DOB);

        }
        public void display(Course course) 
        {
            Console.WriteLine(course);

        }

    public void display(Enroll enroll)
    {
        Console.WriteLine(enroll);

    }
}
