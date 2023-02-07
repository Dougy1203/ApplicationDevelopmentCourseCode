using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Classes
    {
        public static void Execute()
        {
            ExampleProps sp = new ExampleProps();
            //sp.prop2 = "stuff";
            //string s = sp.GetProp3;


            //CREATE MATH class (dont want to create an instance - helper / utility classes
            //Show how you cant make instance if static
            //Math math = new Math();
            float area = 2 * Math.PI * 2.0f; // 2PIr
            area = Math.CalculateArea(2.0f);

            //CREATE STUDENT class
            Student milton = new Student();
            //assignment operator uses the setter
            milton.Name = "Milton";
            //this uses the getter
            Console.WriteLine("Students name is: {0}", milton.Name);

            //checks in setter / also shows string formatter for showing decimals
            milton.GPA = 10f;
            Console.WriteLine("Miltions GPA: {0:0.0}", milton.GPA);
            milton.GPA = 3.6f;
            Console.WriteLine("Miltions GPA: {0:0.0}", milton.GPA);

            //Auto property test (test without set? )
            Console.WriteLine("Miltons Age: {0}", milton.Age);

            //ADD CONSTRUCTOR(s)
            Student aaron = new Student();
            //show without optional param
            Student aaron2 = new Student("Aaron", 36, 3.5f);

            //ADD STATIC FIELD NUMBEROFSTUDENTS
            milton.HowManyStudents();


            milton.HowManyStudents();
            aaron.HowManyStudents();

            //make the HowManyStudents static so you dont need instance
            //static methods/fields can use other static methods fields
            //Student.HowManyStudents();

            //CREATE CLASS ALUMNI

        }
    }

    //marking this class static is not required, but it blocks this class from being instantiated.
    static class Math
    {
        // constant values cannot be changed after created
        public const float PI = 3.14159f;

        //if we dont mark our class static, and leave static off this, 
        //it requires an instance to be seen.
        public static float CalculateArea(float radius)
        {
            return 2 * PI * radius;
        }
    }

    class ExampleProps
    {

        public string prop2;  // quick and easy, but saving/loading not controlled or validated
        private string prop3; // better - create private variables, control access with properties

        public string GetProp3
        {
            get
            {
                return prop3;
            }
            set
            {
                prop3 = value;
            }
        }


    }

    class Student
    {
        /*
         * Classes have members
         * Members include fields, properties, methods, constructors (events, indexers, constants, operators, finalizers, nested types)
         * Includes all the class members plus any in the inheritance chain.
         */

        //Fields - typically private / internal data
        private string name;
        private int cohort = 36;
        private float gpa;

        //properties - typically public, what we want to expose (WILL BE USED IN UWP WHEN WE GET THERE)
        //propfull for shortcut
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float GPA
        {
            get { return gpa; }
            set
            {
                if (value >= 0 && value <= 4.0)
                {
                    gpa = value;
                }
            }
        }

        //Auto-Implemented property - Auto creates a private, anonymous backing field only accessable through get/set 
        //get or set is not required
        public int Age { get; set; } = 21;

        //Constructors - has default auotmatically if you dont define it
        //has no return type
        //this overrides default constructor, as long as no params
        public Student()
        {
            //if you exclude set on Age, Age is immutable everywhere except the constructor
            Age = 26;
            Console.WriteLine("In constructor");
            numberOfStudents++;
        }

        //overload constructor - optional params at end
        public Student(string name, int cohort, float gpa = 2.5f)
        {
            //this refers to this instance of student
            this.name = name;
            this.gpa = gpa;
            this.cohort = cohort;
            numberOfStudents++;
        }

        //using static field to make sure all students share a value
        static int numberOfStudents = 0;

        public void HowManyStudents()
        {
            Console.WriteLine("Number of students: {0}", numberOfStudents);
        }

    }

    //Derived from student. They are a subset of it
    //Functionality in student is available in Alumni
    class Alumni : Student
    {
        private int yearGraduated;

        public Alumni()
        {
            //Protection levels
            //  Public - accessable to everyone
            //  Private - Only this class can see it
            //  Protected - this class and any class that inherits from it
            //  Internal - Accessable to this assembly or project (assembly is the compiled code that is created)

            //CHANGE NAME on student class TO PROTECTED so this works
            //Console.WriteLine("Alumni Name: {0}", name);
        }

        //ability to call base constructor
        public Alumni(string name, float gpa, int cohort, int yearGraduated) : base(name, cohort, gpa)
        {
            this.yearGraduated = yearGraduated;
        }
    }
}
