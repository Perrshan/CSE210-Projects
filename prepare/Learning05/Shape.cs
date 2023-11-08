public class Shape{
    private string _color;

    public Shape(string color){
        _color = color;
    }

    public string GetColor(){
        return _color;
    }

    protected void SetColor(string color){
        _color = color;
    }

    public virtual double GetArea(){
        double area = 0.0;
        return area;
    }
}