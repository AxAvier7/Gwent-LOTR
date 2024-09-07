public class LexError
{
    public string Message { get; }
    public int Line { get; }
    public int Column { get; }

    public LexError(string message, int line, int column)
    {
        Message = message;
        Line = line;
        Column = column;
    }

    public override string ToString() => $"Error: '{Message}' , Linea: {Line}, Columna: {Column}";
}