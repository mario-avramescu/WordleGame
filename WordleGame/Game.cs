namespace WordleGame;

public class Game(ITextTerminal textTerminal)
{
    private readonly GameRunner runner = new();
    private readonly GameTerminal terminal = new(textTerminal);

    public void StartGame() 
    {
        textTerminal.WriteText($"Welcome to the Wordle Game! Only words that have 5 letters are valid.\n");
        runner.RunGame((randomWord) => {
            var word = terminal.ReadWord().ToLower();
            terminal.WriteResult(word, randomWord);
            return word;
        }, textTerminal);
    }
}