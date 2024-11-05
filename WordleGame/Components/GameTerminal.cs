namespace WordleGame.Components;

internal sealed class GameTerminal(ITextTerminal terminal)
{
    private readonly WordReader wordReader = new(terminal);
    private readonly ResultWriter resultWriter = new(terminal);

    public string ReadWord() => wordReader.ReadWord();
    public void WriteResult(string result, string randomNumber) => resultWriter.WriteResult(result, randomNumber);
}