using System;

//The Journal class makes the _entryList. Creates a Display, Save, and Load Method.
public class Journal
{
    public List<Entry> _entryList = new List<Entry>();

    //Display each of the entries in the _entryList
    public void Display()
    {
        foreach (Entry entry in _entryList)
        {
            entry.Display();
        }
    }

    //Saves the entries into a user inputted file and calls a method to concatenate the entries for easy reading.
    public void Save(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        { 
            foreach(Entry entry in _entryList)
            {
                string fileLine;
                fileLine = entry.Save();

                outputFile.WriteLine($"{fileLine}");
            }
        }
    }

    //Reads the lines from a file and deconstructs the concatenated line to assign them to the Entry instances.
    public Journal Load(string fileName, Journal myJournal)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split("~");

            
            string dateLine = parts[0];
            string promptLine = parts[1];
            string entryLine = parts[2];

            entry._date = dateLine;
            entry._prompt = promptLine;
            entry._entry = entryLine;

            myJournal._entryList.Add(entry);
        }
        return myJournal;
    }

}