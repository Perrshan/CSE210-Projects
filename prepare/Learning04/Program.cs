using System;

class Program
{
    static void Main(string[] args)
    {

        Assignment assignment = new Assignment("Harry Perry", "Multiplication");

        Console.WriteLine(assignment.GetSummary());

        Console.WriteLine();

        MathAssignment mathAssignment = new MathAssignment("Harry Perry", "Multiplication", "8.9", "18-23");

        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment("Harry Perry", "Research Paper", "Got Milk?");

        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }

    /*

    public class Shape {
        private string _color;

        protected Shape(string color){
            _color = color;
        }
    }

    public class Circle: Shape {
        private float _radius;

        public Circle(string color, float radius) : base(color){
            _radius = radius;
        }

        public float Area() {
            float pi = (float) 3.14;
            return pi * _radius * _radius;
        }
    }

    public class Sqaure: Shape {
        private float _sideLength;

        public Sqaure(string color, float sideLength) : base(color){
            _sideLength = sideLength;
        }

        public float Area() {
            return _sideLength * _sideLength;
        }
    }
    
    
    /*public class Vehicle {
        private string _make;
        private string _model;
        private int _miles;

        // make it protected since we will never just need a vehicle variable
        protected Vehicle(string make, string model, int miles){
            _make = make;
            _model = model;
            _miles = miles;
        }
    }

    public class Car: Vehicle {

        public Car(string make, string model, int miles) : base(make, model, miles){

        }
    }

    public class Truck: Vehicle {
        private int _towing;

        public Truck(string make, string model, int miles, int towing) : base(make, model, miles){
            _towing = towing;
        }

    }*/

    /*    public class Person {
            private string _id;
            protected string _name;

            public Person(string id, string name) {
                _id = id;
                _name = name;
            }

            public void Display() {
                System.Console.WriteLine($"Name = {_name}");
            }
        }

        public class Student: Person {
            private string _major;

            public Student(string studentName, string studentId, string major) : base(studentId, studentName) {
                _major = major;
            }

            public void DisplayStudentSummary() {
                Console.WriteLine($"{_name}: {_major}");
            }
        }

        public class Employee: Person {
            private string _department;
        }
        */

    
}
