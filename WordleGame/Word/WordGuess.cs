namespace WordleGame.Word;

internal sealed class WordGuess
{
    private readonly Random random = new();
    public List<string> Words;

    public WordGuess()
    {
        if (string.IsNullOrWhiteSpace("words.txt"))
        {
            throw new ArgumentException("File path cannot be null or empty.");
        }
        
        try
        {
            Words = File.ReadAllLines("words.txt").Where(word => word.Length == 5).ToList();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Could not read the words file.", ex);
        }

        if (Words.Count == 0)
        {
            throw new InvalidOperationException("No valid words found in the file.");
        }
    }

    public string GenerateRandomWord()
    {
        int randomIndex = random.Next(Words.Count);
        return Words[randomIndex];
    }
}