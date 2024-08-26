public class Lexer
{
    private readonly string _input;
    private int _position;
    private int _line;
    private int _column;
    public List<LexError> Errors {get;}

    private static readonly HashSet<string> Keywords = new HashSet<string>
    {
        "Type", "Name", "Faction", "Power", "OnActivation", "Effect", "Selector", "PostAction", "Predicate",
        "For", "While", "Card", "CardSharpEffect", "Params", "Action", "Source", "Single", "In"
    };
    private static readonly HashSet<string> Range = new HashSet<string>
    {
        "Melee", "Ranged", "Siege"
    };
    private static readonly HashSet<string> Factions = new HashSet<string>
    {
        "Comunidad del Anillo", "Mordor", "None"
    };

    private static readonly HashSet<string> Types = new HashSet<string>
    {
        "Oro", "Plata", "Lider", "Aumento", "Clima"
    };

    private static readonly HashSet<string> BooleanValues = new HashSet<string>
    {
        "true", "false"
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
            '@' => TokenType.Arroba,
            '<' => TokenType.MinorSign,
            '>' => TokenType.MajorSign,
            // '==' => TokenType.Equal,
            ':' => TokenType.TwoPoints,
            ',' => TokenType.Comma,
            // '&&' => TokenType.And,
            // '||' => TokenType.Or,
            // '++' => TokenType.MasMas,
            // '--' => TokenType.MenosMenos,
            // '+=' => TokenType. MasIgual,
            // '-=' => TokenType.MenosIgual,
            // '*=' => TokenType.MultiplicacionIgual,
            // '/=' => TokenType.DivisionIgual,
            // '!=' => TokenType.Desigual,
            '=' => TokenType.Asignacion,
            // '@@' => TokenType.StringConcat,
            // '=>' => TokenType.Implicacion,
            '(' => TokenType.ParAb,
            ')' => TokenType.ParCer,
            '[' => TokenType.CorAb,
            ']' => TokenType.CorCer,
            '{' => TokenType.LlaveAb,
            '}' => TokenType.LlaveCer,
            _ => TokenType.Unknown
        };

        if (_position < _input.Length && (_input[_position] == '/' && _input[_position] == '/'))
        {
            Errors.Add(new LexError($"Commentaries not admited: {current}/" , startline, startcol));
        }

        if(type == TokenType.Unknown)
        {
            Errors.Add(new LexError($"Invalid token: {current}" , startline, startcol));
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
                Errors.Add(new LexError("Unfinished string", _line, _column));
                return new Token(TokenType.Unknown, _input.Substring(start, _position - start), startline, startcol);
            }
            AvancePos();
        }

        if (_position >= _input.Length)
        {
            Errors.Add(new LexError("Unfinished string", startline, startcol));
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
        else if (Types.Contains(value))
        {
            return new Token(TokenType.Type, value, startline, startcol);
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

    // private void Coincidencia(List<Token> tokens, string _input, int _line, int _column, TokenType type = TokenType.TyDollaSign)
    // {
    //     try
    //     {
    //         tokens.Add(new Token((type == TokenType.TyDollaSign? Token.AllTokens[_input] : type), _input, _line + 1, _column + 1));
    //     }
    //     catch (KeyNotFoundException)
    //     {
    //         tokens.Add(new Token(TokenType.IDs, _input, _line + 1, _column + 1));
    //         Token.AllTokens.Add(_input, TokenType.IDs);
    //     }
    //     _column += _input.Length - 1;
    // }
}