namespace WordleGame.Results;

internal sealed class ResultWriter(ITextTerminal terminal)
{
    private const string ResultMessage = "> Word guess: ";
    private const string CorrectLetterPosition = "\x1b[92m"; 
    private const string CorrectLetter = "\x1b[93m"; 
    private const string ResetColor = "\x1b[0m";

    private readonly ITextTerminal terminal = terminal;

    public void WriteResult(string guessedWord, string targetWord)
    {
        var letterCountDictionary = BuildLetterCountDictionary(targetWord);
        var finalResult = new System.Text.StringBuilder();

        for (int i = 0; i < guessedWord.Length; i++)
        {
            char currentLetter = guessedWord[i];

            if (currentLetter == targetWord[i])
            {
                finalResult.Append($"{CorrectLetterPosition}{currentLetter}");
            }
            else if (targetWord.Contains(currentLetter) && letterCountDictionary[currentLetter] > 0)
            {
                finalResult.Append($"{CorrectLetter}{currentLetter}");
            }
            else
            {
                finalResult.Append($"{ResetColor}{currentLetter}");
            }

            if (letterCountDictionary.ContainsKey(currentLetter))
            {
                letterCountDictionary[currentLetter]-= 1;
            }
        }

        terminal.WriteText($"{ResultMessage}{finalResult}{ResetColor}\n");
    }

    private static Dictionary<char, int> BuildLetterCountDictionary(string word)
    {
        var letterCount = new Dictionary<char, int>();

        foreach (char letter in word)
        {
            if (letterCount.TryGetValue(letter, out int count))
            {
                letterCount[letter] = count + 1;
            }
            else
            {
                letterCount[letter] = 1;
            }
        }

        return letterCount;
    }
}
