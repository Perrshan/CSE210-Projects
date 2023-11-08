using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("blue", 7));
        shapes.Add(new Rectangle("green", 7, 3));
        shapes.Add(new Circle("pink", 18));

        foreach(Shape shape in shapes){
            Console.WriteLine($"{shape.GetColor()} {shape.GetArea()}");
        }

    }
}
