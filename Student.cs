using System;



    public class Student
    {
        string id;
        string name;
    
        DateTime dateOfBirth;
    string particularCourseType;


    public Student()
    {
    }

    public Student(string id, string name, DateTime dateOfBirth, String particularCourseType)
        {
            
            this.id = id;
            this.name = name;
            this.dateOfBirth = (DateTime)dateOfBirth;
            this.particularCourseType=particularCourseType;
}

        public string Id 
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DOB
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public String ParticularCourseType
    {
        get { return particularCourseType; }
        set { particularCourseType = value; }
    }

        public override string ToString()
        {


            return  Id + "\t" + Name + "\t" + dateOfBirth.ToShortDateString()+"\t"+  particularCourseType ;
        }
    }