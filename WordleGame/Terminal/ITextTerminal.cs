namespace WordleGame.Terminal;

public interface ITextTerminal
{
    string? ReadText();
    void WriteText(string text);
}