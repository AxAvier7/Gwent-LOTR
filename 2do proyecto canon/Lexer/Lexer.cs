public class Lexer
{
    private readonly string _input;
    private int _position;
    private int _line;
    private int _column;
    public List<LexError> Errors {get;}

    public bool esrango = false;

    private static readonly HashSet<string> Keywords = new HashSet<string>
    {
        "Type", "Name", "Faction", "Power", "OnActivation", "Effect", "Selector", "PostAction", "Predicate"
    };
    private static readonly HashSet<string> Range = new HashSet<string>
    {
        "Melee", "Ranged", "Siege"
    };
    private static readonly HashSet<string> Factions = new HashSet<string>
    {
        "Comunidad del Anillo", "Mordor", "None"
    };

    public Lexer(string input) //works fine
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

            if (char.IsWhiteSpace(current)) //works fine
            {
                AvancePos();
                continue;
            }

            if (char.IsLetter(current))
            {
                var token = ReadWord();
                tokens.Add(token);
            }

            else if (char.IsDigit(current)) //works fine
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
                if (token.Type != TokenType.Unknown)
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

            if (word == "Power" && _position < _input.Length && _input[_position] == ':')
                {
                    AvancePos();

                    while (_position < _input.Length && _input[_position] != ',')
                    {
                        AvancePos();
                    }

                    string value = _input.Substring(start, _position - start).Trim();
                    return new Token(TokenType.Power, value, startLine, startColumn);
                }
            return new Token(type, word, startLine, startColumn);
        }

    // private Token ReadBracketedString()
    // {
    //     int startLine = _line;
    //     int startCol = _column;
    //     int start = _position;
    //     _position++;
    //     _column++;

    //     while (_position < _input.Length && _input[_position] != ']')
    //     {
    //         if (_input[_position] == '\n')
    //         {
    //             Errors.Add(new LexError("String entre corchetes sin terminar", _line, _column));
    //             return new Token(TokenType.Unknown, _input.Substring(start, _position - start), startLine, startCol);
    //         }
    //         AvancePos();
    //     }

    //     if (_position >= _input.Length)
    //     {
    //         Errors.Add(new LexError("String entre corchetes sin terminar", startLine, startCol));
    //         return new Token(TokenType.Unknown, _input.Substring(start, _position - start), startLine, startCol);
    //     }

    //     string word = _input.Substring(start, _position - start);
    //     _position++;
    //     _column++;

    //     if (esrango && Range.Contains(word))
    //     {
    //         esrango = false;
    //         return new Token(TokenType.Range, word, startLine, startCol);
    //     }

    //     return new Token(TokenType.StringCont, word, startLine, startCol);
    // }

    private Token ReadNumber() //works fine
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

    private Token ReadSymbol() //works fine
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
            ':' => TokenType.TwoPoints,
            '=' => TokenType.EqualSign,
            ',' => TokenType.Comma,
            '<' => TokenType.MinorSign,
            '>' => TokenType.MajorSign,
            _ => TokenType.Unknown
        };

        if(type == TokenType.Unknown)
        {
            Errors.Add(new LexError($"Simbolo no valido: {current}" , startline, startcol));
        }

        return new Token(type, current.ToString(), startline, startcol);
    }

    private Token ReadString(TokenType tokenType)
    {
        int startline = _line;
        int startcol = _column;
        int start = _position;
        _position++;
        _column++;

        while (_position < _input.Length && _input[_position] != '"')
        {
            if (_input[_position] == '\n')
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

        string value = _input.Substring(start + 1, _position - start - 1);
        _position++;
        _column++;

        if (Range.Contains(value))
        {
            return new Token(TokenType.Range, value, startline, startcol);
        }
        else if (Factions.Contains(value))
        {
            return new Token(TokenType.Faction, value, startline, startcol);
        }

        return new Token(tokenType, value, startline, startcol);
        }

    private void AvancePos() //works fine
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

    // public bool ContinuaCon(string Substring)
    // {
    //     if (_position + Substring.Length > _input.Length)
    //         return false;
    //     for (int i = 0; i < Substring.Length; i++)
    //         if (_input[_position + i] != Substring[i])
    //             return false;
    //     return true;
    // }

    // public char RevisarSig()
    // {
    //     if (_input < 0 || _position >= _input.Length) throw new InvalidOperationException();
    //     return _input[_position];
    // }

    // public bool Coincidencia(string Substring)
    // {
    //     if (ContinuaCon(Substring))
    //     {
    //         _position += Substring.Length;
    //         return true;
    //     }
    //     return false;
    // }
}