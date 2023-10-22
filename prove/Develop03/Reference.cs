class Reference
{

    // make instances
    private string _book;
    private string _chapter;
    private string _verse;

    // constructor that assigns the default proverbs scripture
    public Reference()
    {
        _book = "Proverbs";
        _chapter = "3";
        _verse = "5-6";
    }

    // contructor that assigns custom values to the reference instances
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // displays the reference in the correct format
    public void Display()
    {
        Console.Write($"{_book} {_chapter}:{_verse} ");
    }
}