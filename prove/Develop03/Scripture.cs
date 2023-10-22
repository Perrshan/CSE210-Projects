class Scripture
{
    // creates a Word list
    private List<Word> _wordList = new List<Word>();

    // allows the program class to add words to the _wordList
    public void AddWordList(Word word)
    {
        _wordList.Add(word);
    }

    // gets 3 different random numbers and then finds the corresponding Word[INDEX] in the _wordList to hide that word
    public void HideWords()
    {
        for (int i = 0; i<3; i++)
        {
            int count = 0;
            Random rnd = new Random();
            int randomInt = rnd.Next(0, _wordList.Count);
            foreach (Word word in _wordList)
            {
                if(count == randomInt)
                {
                    word.Hide(_wordList[randomInt]);
                }
                count ++;
            }
        }
    }

    // displays the list
    public void GetRenderedList()
    {
        foreach (Word word in _wordList)
        {
            word.Display();
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // checks to see if all the words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _wordList)
        {
            if(!word.GetIsHidden())
            {
                return false;
            }
        }
        return true;
    }
}