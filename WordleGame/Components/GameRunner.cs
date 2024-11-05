namespace WordleGame.Components;

internal sealed class GameRunner
{
    public string RandomWord { get; private set; }

    public GameRunner()
    {
        RandomWord = new WordGuess().GenerateRandomWord(); 
    }

    public void RunGame(Func<string, string> gameFunc, ITextTerminal terminal)
    {
        while (true)
        {
            var word = gameFunc(RandomWord);
            if (word == RandomWord)
            {
                terminal.WriteText($"[Game] Congratulations! You discovered the word \x1b[93m{word}. \n");
                return;
            }
            else
            {
                terminal.WriteText($"[Game] Try again! \n");
            }
        }
    }
}
