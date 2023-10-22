class Word
{

    // make instances
    private string _word;
    private bool _isHidden;

    // constructor to make the new words along with setting _isHidden to false
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    // allows other classes to get the value of _isHidden of any Word
    public bool GetIsHidden(){
        bool isHidden = _isHidden;
        return isHidden;
    }

    // if a word is not hidden then it will write the word, and if it is hidden then it will display it as underscores instead
    public void Display()
    {
        if(!_isHidden)
        {
        Console.Write($"{_word}" + " ");
        } else {
            int length = _word.Length;
            Console.Write(RepeatLinq("_", length) + " ");
        }
    }

    // makes words hidden
    public void Hide(Word word)
    {
        _isHidden = true;
    }


    // I got this from: https://blog.nimblepros.com/blogs/repeat-string-in-csharp/ and slightly edited it for my code
    // this prints underscores instead of each letter of a word.
    private string RepeatLinq(string text, int n)
    {
        return string.Concat(System.Linq.Enumerable.Repeat(text, (int)n));
    }
}