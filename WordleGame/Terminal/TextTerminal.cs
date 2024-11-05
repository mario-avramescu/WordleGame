namespace WordleGame.Terminal;

internal class TextTerminal : ITextTerminal
{
    public string? ReadText() => Console.ReadLine();
    public void WriteText(string text) => Console.Write(text);
}