using System;
using System.Collections.Generic;
using System.Linq;

public class Enroll
{

    Student student;
     Course course;
    DateTime enrollmentDate;
    

    public List<DiplomaCourse> DiplomaCourseList =new List<DiplomaCourse>();
    public List<DegreeCourse> DegreeCourseList= new List<DegreeCourse>();
     public List<Student> StudentList = new List<Student>();
    

    public List<Course> CourseList =new List<Course>();

    public List<Enroll> EnrollmentList =new List<Enroll>();
    public Enroll(Student student, Course course, DateTime enrollmentDate)
    {
        this.student = student;
        this.course = course;
        this.enrollmentDate = enrollmentDate;
    }

    public Enroll()
    {
    }

    public int getEnrollmentCount() {
        return EnrollmentList.Count();
    
    }

    public void IntroduceNewDiplomacourse(Course dipcourse)
    {

        DiplomaCourseList.Add((DiplomaCourse)dipcourse);

    }


    public void IntroduceNewDegreeCourse(Course degcourse)
    {

        DegreeCourseList.Add((DegreeCourse)degcourse);

    }


    public List<DiplomaCourse> listOfDiplomaCourses()
    {

        return DiplomaCourseList;
    }

    public List<DegreeCourse> listOfDegreeCourses()
    {

        return DegreeCourseList;
    }



    public void register(Student student)
    {
        StudentList.Add(student);
        
    }

    public List<Student> listOfStudents()
    {
        return StudentList;
    }

    public void enroll(Student student, Course course, DateTime enrollmentDate)
    {
        EnrollmentList.Add(new Enroll(student, course, enrollmentDate)) ;
        
    }

    public List<Enroll> listOfEnrollments()
    {
        return EnrollmentList;
    }



    public bool checkCourseIfAlreadySelected(String sid, String cid, List<Enroll> EnrollmentList)
    {

        if (EnrollmentList != null)
        {

            for (int i = 0; i < EnrollmentList.Count(); i++)

            {
                if (EnrollmentList.ElementAt(i) != null)
                {
                    if (EnrollmentList.ElementAt(i).student.Id == sid)

                    {
                        if ((EnrollmentList.ElementAt(i).course.CourseId) == cid)

                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
   
    public override string ToString()
    {


        return "\t" + student + "\t" + course + "\t" + enrollmentDate.ToShortDateString();
    }
}

