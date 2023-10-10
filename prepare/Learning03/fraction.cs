
// creates private variables, constructors, and methods to work with various fractions
class Fraction
{
    // creates private instances
    private int _top;
    private int _bottom;

    // makes a constructor with no arguments
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // makes a constructor with a single argument for top
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // makes a constructor with arguments for both top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // gets the top value
    public int GetFractionTop()
    {
        return _top;
    }

    //sets the top value
    public void SetFractionTop(int top)
    {
        _top = top;
    }

    // gets the bottom value
    public int GetFractionBottom()
    {
        return _bottom;
    }

    // sets the bottom value
    public void SetFractionBottom(int bottom)
    {
        _bottom = bottom;
    }

    // creates a one time string to display top and bottom in a fraction format
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    // creates a one time double value to show the decimal value of top and bottom
    public double GetDecimalValue()
    {
        double result = ((double)_top / (double)_bottom);
        return result;
    }

}