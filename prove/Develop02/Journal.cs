using System;

public class Journal
{
    public List<Entry> _entryList = new List<Entry>();

    public void Display()
    {
        foreach (Entry entry in _entryList)
        {
            entry.Display();
        }
    }

    public void Save(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        { 
            foreach(Entry entry in _entryList)
            {
                string fileLine;
                fileLine = entry.Save();

                // You can add text to the file with the WriteLine method
                outputFile.WriteLine($"{fileLine}");
            }
        }
    }

    public Journal Load(string fileName, Journal myJournal)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split("~");

            string promptLine = parts[0];
            string dateLine = parts[1];
            string entryLine = parts[2];

            entry._prompt = promptLine;
            entry._date = dateLine;
            entry._entry = entryLine;

            myJournal._entryList.Add(entry);
        }
        return myJournal;
    }

}