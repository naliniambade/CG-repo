using System;
using System.Collections.Generic;

class Utility
    {

    public Course getCourseDetailsById(String cId, List<DegreeCourse> deg_CourseList, List<DiplomaCourse> dip_CourseList)
    {

        
        Course c1 =null;
        if (deg_CourseList != null)
        {
            foreach (Course c in deg_CourseList)
            {
                if (c != null)
                {

                    if ((c.CourseId) == cId)
                    {
                        c1 = c;
                    }
                }
            }
        }
        if (dip_CourseList != null)
        {

            foreach (Course c in dip_CourseList)
            {
                if (c != null)
                {

                    if ((c.CourseId) == cId)
                    {
                        c1 = c;
                    }
                }
            }
        }
        return c1;
    }

    public int totalSeatsCount(String cId, List<DegreeCourse> deg_CourseList, List<DiplomaCourse> dip_CourseList)
    {
        int s = 0;

        foreach (Course c in dip_CourseList)
        {
            if (c != null)
            {

                if ((c.CourseId) == cId)
                {
                    s = c.seatsavaialble;
                }
            }
        }

        foreach (Course c in deg_CourseList)
        {
            if (c != null)
            {

                if ((c.CourseId) == cId)
                {
                    s = c.seatsavaialble;
                }
            }
        }

        return s;
    }
    




    public bool checkStudentIdExist(String id, List<Student> StudentList)
    {
        if (StudentList != null)
        {

            foreach (Student s in StudentList)
            {

                if (s != null)
                {
                    if ((s.Id) == id)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    

    public bool checkIfCourseIdExist(String id, List<DiplomaCourse> CourseList)
    {

        if (CourseList != null)
        {
            foreach (Course c in CourseList)
            {

                if (c != null)
                {
                    if ((c.CourseId) == id)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }



    public bool checkIfCourseIdExist(String id, List<DegreeCourse> CourseList)
    {

        if (CourseList != null)
        {
            foreach (Course c in CourseList)
            {

                if (c != null)
                {
                    if ((c.CourseId) == id)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public bool checkIfSeatsAvailable(int EnrollementCount, int seatsavaialble)
    {
        if ((EnrollementCount + 1) <= seatsavaialble)
            return true;


        return false;
    }

}
    class OutOfLimitException : Exception
    {
        public OutOfLimitException(string message) : base(message)
        {
        }
    }
    class AlreadyRegisteredCourse : Exception     //student registering again for same course
    {
        public AlreadyRegisteredCourse(string message) : base(message)
        {
        }
    }

    

    class DuplicateIDException : Exception
    {
        public DuplicateIDException(string message) : base(message)
        {
        }
    }
    class CourseIDNotExistException : Exception
    {
        public CourseIDNotExistException(string message) : base(message)
        {
        }
    }


    class StudentIDNotExistException : Exception
    {
        public StudentIDNotExistException(string message) : base(message)
        {
        }
    }







