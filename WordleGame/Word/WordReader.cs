namespace WordleGame.Word;

internal sealed class WordReader(ITextTerminal textTerminal)
{
    const string HeaderMessage = "> Word: ";
    const string ErrorMessage = "[Error] The word should contain only 5 letters!";

    private readonly ITextTerminal terminal = textTerminal;

    public string ReadWord() 
    {
        terminal.WriteText(HeaderMessage);

        var word = terminal.ReadText();
        if(word != null && word.Length == 5)
            return word;

        terminal.WriteText(ErrorMessage + "\n");
        return ReadWord();
    }
}