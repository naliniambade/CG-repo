using System;
using System.Linq;

class ScreenDescription : UserInterface
    {
        
        Info info = new Info();
        Enroll en = new Enroll();
        Utility ut = new Utility();

    public void showFirstScreen()
    {

        Console.WriteLine("Welcome to Student Management System");
        Console.WriteLine("Tell us who you are : \n\t1. Student\n\t2. Admin\n\t3.Exit\n");
        Console.WriteLine("Enter your choice ( 1 or 2 or 3) : ");
       
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    showStudentScreen();
                    break;
                case 2:
                    showAdminScreen();
                    break;
                case 3:
                    Exit();
                    break;
            default:
                Console.WriteLine("Please enter correct choice");
                break;
        }
        
    }

    public void showStudentScreen()
    {
        Console.WriteLine("----You are in student screen----");
        bool flagS = false;
        while(!flagS)
        {
            Console.WriteLine("\nEnter your choice:\n1.Student Registration\n2.Enroll for Course" +
            " \n3.Show all Student Enrollments\n4.Show all Student Details\n5.Exit\n");
            
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        showStudentRegistrationScreen();
                        break;
                    case 2:
                        showEnrollmentScreen();
                        break;
                    case 3:
                        showAllEnrollments();
                        break;
                    case 4:
                        showAllStudentsScreen();
                        break;
                    case 5:
                        flagS = true;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


        } 
    }

    public void showStudentRegistrationScreen() 
    {
        Console.WriteLine("----You are in student registration screen----");
        Console.WriteLine("Enter student id:");
        string id = Console.ReadLine();

        if (ut.checkStudentIdExist(id, en.listOfStudents())) {
            throw new DuplicateIDException(" Student Id Already Exists...try Again...");
        
        }
        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine();


        Console.WriteLine("Enter Registration for(1 or 2):\n 1. Diploma\n 2.Degree\n");
        
        try
        {
            string particularCourseType =null;

            int t = int.Parse(Console.ReadLine());
            
            if (t == 1)
                particularCourseType = "Diploma";
            else if (t == 2)
                particularCourseType = "Degree";
            else
                Console.WriteLine("Enter  1 or 2");
       

        Console.WriteLine("Enter date of birth in format \"MM/DD/YYYY\"");
        string date = Console.ReadLine();
        DateTime dateOB = Convert.ToDateTime(date);
        en.register(new Student(id, name, dateOB, particularCourseType));

        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    public void showAllStudentsScreen()
    {

        Console.WriteLine("----You are in all students screen----");
        Console.WriteLine("\t| Id\t| Name\t| Date of Birth\t|ParticularCourseType\n");
        foreach (Student student in en.listOfStudents())
            info.display(student);
    }

    public void showAllEnrollments()
    {
       Console.WriteLine("\t| Student_Id\t| Name\t| Date of Birth\t|ParticularCourseType\t|Course_Id\t|Course_name\t|Duration\t|Fees\tSeatsAvailable\t|Enroll_Date\n");

        foreach (Enroll enroll in en.listOfEnrollments()){
            info.display(enroll);
        }
            
    }

    public void showEnrollmentScreen()
    {
        Student student1 = new Student();
        Course course;
        Console.WriteLine("Enter student id");
        string id = Console.ReadLine();
       
        if (!ut.checkStudentIdExist(id, en.listOfStudents())) {
            throw new StudentIDNotExistException("Student ID DOES NOT Exist in System..Please Register and try again");
        }


        for (int i = 0; i < en.StudentList.Count(); i++)
        {
            if (id == (en.StudentList.ElementAt(i).Id))
            {
                student1 = en.StudentList.ElementAt(i);
            }
        }


        Console.WriteLine("Enter course id");
        string courseid = Console.ReadLine();
        Console.WriteLine("Enter Diploma Course or Degree course");
        string c_type = Console.ReadLine();

        if ((!ut.checkIfCourseIdExist(courseid, en.listOfDiplomaCourses()) && c_type=="Diploma" )|| (!ut.checkIfCourseIdExist(courseid, en.listOfDegreeCourses()) && c_type == "Degree")) {
            throw new CourseIDNotExistException("Course ID DOES NOT exist..try Again");
        }
        
             if(en.checkCourseIfAlreadySelected(id,courseid, en.listOfEnrollments()))
                {
                    throw new AlreadyRegisteredCourse("Already Registered for this course");
                }
                
                else if(!ut.checkIfSeatsAvailable(en.getEnrollmentCount(), ut.totalSeatsCount(courseid, en.listOfDegreeCourses(), en.listOfDiplomaCourses())))
                {
                    throw new OutOfLimitException("Seats not available");
                }

                else
                {
                    course = ut.getCourseDetailsById(courseid, en.listOfDegreeCourses(), en.listOfDiplomaCourses());
                }
           
        
        

        en.enroll(student1, course, DateTime.Now);
    }

    public void showStudentDetailsById()
    {
        Console.WriteLine("Enter student ID");
        string id = Console.ReadLine();

        if (!ut.checkStudentIdExist(id, en.listOfStudents()))
        {
            throw new StudentIDNotExistException("Student Id Does not Exist in System.. try again");
        }

        Console.WriteLine("|Id\t|Name\t|Date of Birth\n");
        foreach (Student student in en.listOfStudents())
        {
            
            if (student != null)
            {
                if (student.Id.Equals(id))
                {
                    info.display(student);
                }
            }
            
            
        }
    }

    public void showAdminScreen()
    {
        Console.WriteLine("You are in admin screen");
        Console.WriteLine("---Welcome to Admin Dashboard---");

        bool flagC = false;
        while (!flagC)
        {
            Console.WriteLine("\nEnter your choice:\n1.Show all Student Details\n2.Show all current Student Enrollments\n" +
            "3.Introduce new course\n4.Show all courses\n5.Display Student Details by ID\n6.Exit\n");
            
            try{
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        showAllStudentsScreen();
                        break;
                    case 2:
                        showAllEnrollments();
                        break;
                    case 3:
                        introduceNewCourseScreen();
                        break;
                    case 4:
                        showAllCoursesScreen();
                        break;
                    case 5:
                        showStudentDetailsById();
                        break;
                    case 6:
                        flagC = true;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                } }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            }
       
        }

        public void showAllCoursesScreen()
        {
            Console.WriteLine("You are in all courses screen");
            Console.WriteLine("\t| Course Id\t| Course Name\t| Duration\t| Fees\n");
            foreach (Course course in en.listOfDiplomaCourses())
            {
                info.display(course);
            }

        foreach (Course course in en.listOfDegreeCourses())
        {
            info.display(course);
        }
    }
        public void introduceNewCourseScreen()
        {
            Console.WriteLine("You are in introduce new course screen");
            Console.WriteLine("---Add a new Course---");
            Console.WriteLine("Enter the course details to be added:");
            Console.WriteLine("Course ID:");
            string CourseId = Console.ReadLine();

        if (ut.checkIfCourseIdExist(CourseId, en.listOfDiplomaCourses())) {

            throw new DuplicateIDException(" Course ID Already Exist ....try Again");
        }

        if (ut.checkIfCourseIdExist(CourseId, en.listOfDegreeCourses()))
        {

            throw new DuplicateIDException(" Course ID Already Exist ....try Again");
        }



        Console.WriteLine("Course Name:");
            string CourseName = Console.ReadLine();
            Console.WriteLine("Course Duration(in hours):");
            int CourseDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Course Fees:");
            float CourseFees = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Course Seats");
        int seatsavaialble = int.Parse(Console.ReadLine());
       

        try
        {
            Console.WriteLine("Registering Course for(1 or 2):\n 1. Diploma\n 2.Degree\n");
       
       
        
           
            int t = int.Parse(Console.ReadLine());

            if (t == 1)
            {
                Console.WriteLine("Registering Diploma Course Type (1 or 2):\n 1. Professional\n 2. Acdemic\n");
                int t1 = int.Parse(Console.ReadLine());
               
                if (t1 == 1)
                {

                    en.IntroduceNewDiplomacourse(new DiplomaCourse(CourseId, CourseName, CourseDuration, CourseFees, seatsavaialble, Type.Professional));
                }
                else if (t1 == 2)
                    en.IntroduceNewDiplomacourse(new DiplomaCourse(CourseId, CourseName, CourseDuration, CourseFees, seatsavaialble, Type.Acdemic));
                else
                    Console.WriteLine("Enter  (Professional Or Acdemic)");
            }
            else if (t == 2)
            {
                Console.WriteLine("Registering Degree Course Type (1 or 2):\n 1.Bachelors\n2. Masters\n");
                int t1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Placement Available for this Course (Enter true or false)");
                bool isPlacementAvailable = bool.Parse(Console.ReadLine());
                if (t1 == 1)
                {
                    en.IntroduceNewDegreeCourse(new DegreeCourse(CourseId, CourseName, CourseDuration, CourseFees, seatsavaialble, Level.Bachelors, isPlacementAvailable));
                }
                else if (t == 2) {
                    en.IntroduceNewDegreeCourse(new DegreeCourse(CourseId, CourseName, CourseDuration, CourseFees, seatsavaialble, Level.Masters, isPlacementAvailable));
                }
                else {
                    Console.WriteLine("Enter (1.Bachelors or 2. Masters)");
                } }

            else {
                Console.WriteLine("Enter  1 or 2(Diploma Or Degree)");

            }
            }
        
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }


        
        }

    public void Exit() {
        System.Environment.Exit(0);
    }


    }
