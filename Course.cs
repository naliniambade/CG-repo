using System;

public enum RequriedCourse{

    DIPLOMA, DEGREE
}
    public abstract class Course
    {
        string id;
        string name;
        int duration;
        float fees;
    public int seatsavaialble;
    RequriedCourse requriedCourse { get; }


    public Course()
    {
    }

    public Course(string id, string name, int duration, float fees, int seatsavaialble, RequriedCourse requriedCourse)
    {
        this.id = id;
        this.name = name;
        this.duration = duration;
        this.fees = fees;
        this.seatsavaialble = seatsavaialble;
        this.requriedCourse = requriedCourse;
    }

    protected Course(string id, string name, int duration, float fees, int seatsavaialble)
    {
        this.id = id;
        this.name = name;
        this.duration = duration;
        this.fees = fees;
        this.seatsavaialble = seatsavaialble;
    }

    public abstract float calculateMonthlyFee() ;
    




    public string CourseId
        {
            get { return id; }
            set { id = value; }
        }

        public string CourseName
        {
            get { return name; }
            set { name = value; }
        }

        public int CourseDuration
        {
            get { return duration; }
            set { duration = value; }
        }

        public float Fees
        {
            get { return fees; }
            set { fees = value; }
        }

    
}

public enum Level
{

    Bachelors, Masters
}

public class DegreeCourse : Course {

    Level level;

    bool isPlacementAvailable;
    public DegreeCourse(string id, string name, int duration, float fees, int seatsavaialble, Level level, bool isPlacementAvailable): base( id,  name,  duration,  fees, seatsavaialble)
    {
        this.level = level;
        this.isPlacementAvailable = isPlacementAvailable;
    }


    public override float calculateMonthlyFee()
    {
        if (isPlacementAvailable)
            return Fees + Fees * 0.1f;
        return Fees;
    }
    public override string ToString() // from object class overridden method by course class
    {
        return "\t" + CourseId + "\t" + CourseName + "\t" + CourseDuration + "\t" + calculateMonthlyFee()+"\t"+ seatsavaialble+"\t"+level+"\t"+ isPlacementAvailable;
    }

   
}

public enum Type
{
    Professional, Acdemic
}
public class DiplomaCourse : Course
{
    Type type;

    public DiplomaCourse(string id, string name, int duration, float fees, int seatsavaialble, Type type) : base(id, name, duration, fees, seatsavaialble)

    {
        this.type = type; 
    }

    public override float calculateMonthlyFee()
    {
        if (type.Equals(Type.Acdemic))
            return Fees + Fees * 0.05f;
        return Fees + Fees * 0.1f;

    }

    public override string ToString() // from object class overridden method by course class
    {
        return "\t" + CourseId + "\t" + CourseName + "\t" + CourseDuration + "\t" + calculateMonthlyFee() + "\t" + seatsavaialble + "\t" + type ;
    }
}