public class Lexer
{
    private readonly string _input;
    private int _position;
    private int _line;
    private int _column;
    public List<LexError> Errors {get;}

    private static readonly HashSet<string> Keywords = new HashSet<string>
    {
        "Type", "Name", "Faction", "Power", "Range", "Effect", "Selector", "PostAction", "card", "unit", "false", "Predicate", "true", "OnActivation"
    };


    public Lexer(string input)
    {
        _input = input;
        _position = 0;
        _line = 1;
        _column = 1;
        Errors = new List<LexError>();
    }

    public List<Token> Tokenize()
    {
        var tokens = new List<Token>();
        while (_position < _input.Length)
        {
            char current = _input[_position];

            if (char.IsWhiteSpace(current))
            {
                AvancePos();
                continue;
            }

            if (char.IsLetter(current))
            {
                tokens.Add(ReadWord());
            }
            else if (char.IsDigit(current))
            {
                tokens.Add(ReadNumber());
            }
            else if (current == '"')
            {
                tokens.Add(ReadString(TokenType.String));
            }
            else
            {
                Token token = ReadSymbol();
                if (token.Type != TokenType.Unknown || current != ',')
                {
                    tokens.Add(token);
                }
            }

            SkipComas(tokens);
        }

        tokens.Add(new Token(TokenType.EOF, string.Empty, _line, _column));
        return tokens;
    }

    private Token ReadWord()
    {
        int startLine = _line;
        int startColumn = _column;
        int start = _position;
        while (_position < _input.Length && (char.IsLetter(_input[_position]) || char.IsDigit(_input[_position])))
        {
            AvancePos();
        }

        string word = _input.Substring(start, _position - start);
        TokenType type = Keywords.Contains(word) ? TokenType.Reserved : TokenType.IDs;

        if (type == TokenType.Reserved && _position < _input.Length && _input[_position] == ':')
        {
            AvancePos();
            if (_position < _input.Length && _input[_position] == '"')
            {
                return ReadString(TokenType.StringContent);
            }
        }

        return new Token(type, word, startLine, startColumn);
    }

    private Token ReadNumber()
    {
        int start = _position;
        int startLine = _line;
        int startColumn = _column;
        while (_position < _input.Length && char.IsDigit(_input[_position]))
        {
            AvancePos();
        }

        string value = _input.Substring(start, _position - start);
        return new Token(TokenType.Number, value, startLine, startColumn);
    }

    private void SkipComas(List<Token> tokens)
    {
        if (tokens.Count > 0)
        {
            int lastIndex = tokens.Count - 1;
            Token lastToken = tokens[lastIndex];
            if (lastToken.Type == TokenType.Unknown && lastToken.Value == "," && 
                (_position >= _input.Length || _input[_position] == '\n'))
            {
                tokens.RemoveAt(lastIndex);
            }
        }
    }

    private Token ReadSymbol()
    {
        int startline = _line;
        int startcol = _column;
        char current = _input[_position];
        _position++;
        _column++;

        TokenType type = current switch
        {
            '+' => TokenType.Mas,
            '-' => TokenType.Menos,
            '*' => TokenType.Multiplicacion,
            '/' => TokenType.Division,
            '(' => TokenType.ParAb,
            ')' => TokenType.ParCer,
            '[' => TokenType.CorAb,
            ']' => TokenType.CorCer,
            '{' => TokenType.LlaveAb,
            '}' => TokenType.LlaveCer,
            _ => TokenType.Unknown
        };

        if(type == TokenType.Unknown)
        {
            Errors.Add(new LexError($"Simbolo no valido: {current}", startline, startcol));
        }

        return new Token(type, current.ToString(), startline, startcol);
    }

    private Token ReadString(TokenType tokenType)
    {
        int startline = _line;
        int startcol = _column;
        _position++;
        _column++;
        int start = _position;
        while (_position < _input.Length && _input[_position] != '"')
        {
            if(_input[_position] == '\n')
            {
                Errors.Add(new LexError("String sin terminar", _line, _column));
                return new Token(TokenType.Unknown, _input.Substring(start, _position - start), startline, startcol);
            }
            AvancePos();
        }

        if (_position >= _input.Length)
        {
            Errors.Add(new LexError("String sin terminar", startline, startcol));
            return new Token(TokenType.Unknown, _input.Substring(start, _position - start), startline, startcol);
        }

        string value = _input.Substring(start, _position - start);
        _position++;
        _column++;
        return new Token(tokenType, value, startline, startcol);
    }

    private void AvancePos()
    {
        if (_position < _input.Length && _input[_position] == '\n')
        {
            _line++;
            _column = 1;
        }
        else
        {
            _column++;
        }
        _position++;
    }
}