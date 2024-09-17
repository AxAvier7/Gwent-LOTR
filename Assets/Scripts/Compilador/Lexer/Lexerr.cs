using Tookeen;
using System.Text;
using System.Collections.Generic;

namespace Lexing
{
    public class Lexerr
    {
        private readonly string _input;
        private int _position;
        private int _line;
        private int _column;
        public List<LexError> Errors {get;}

        public Lexerr(string input)
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

                if (_position + 1 < _input.Length && _input[_position] == '/' && _input[_position + 1] == '/')
                {
                    Errors.Add(new LexError($"Commentaries not admitted: //", _line, _column));
                    while (_position < _input.Length && _input[_position] != '\n')
                    {
                        AvancePos();
                    }
                    continue;
                }

                if (char.IsWhiteSpace(current))
                {
                    AvancePos();
                    continue;
                }

                if (char.IsLetter(current))
                {
                    var token = ReadWord();
                    tokens.Add(token);
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
                    if (token.Type != TokenType.Unknown)
                    {
                        tokens.Add(token);
                    }
                }
            }

            tokens.Add(new Token(TokenType.EOF, string.Empty, _line, _column));
            return tokens;
        }

        //Comienza a leer una palabra y si la encuentra dentro de los tokens la devuelve con su tipo
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

            if (Token.AllTokens.ContainsKey(word))
            {
                return new Token(Token.AllTokens[word], word, startLine, startColumn);
            }

            return new Token(TokenType.IDs, word, startLine, startColumn);
        }

        //Lee numeros
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

        //Lee simbolos y los identifica con los tokens ya definidos y de no estar los marca como desconocidos
        private Token ReadSymbol()
        {
            int startline = _line;
            int startcol = _column;
            char current = _input[_position];


            switch (current)
            {
                case '[':
                    AvancePos();
                    return new Token(TokenType.CorAb, "[", startline, startcol);
                case ']':
                    AvancePos();
                    return new Token(TokenType.CorCer, "]", startline, startcol);
                case ',':
                    AvancePos();
                    return new Token(TokenType.Comma, ",", startline, startcol);
                case ':':
                    AvancePos();
                    return new Token(TokenType.TwoPoints, ":", startline, startcol);
                case '}':
                    AvancePos();
                    return new Token(TokenType.LlaveCer, "}", startline, startcol);
                default:
                    return HandleOtherSymbols();
            }
        }

        private Token HandleOtherSymbols()
        {
            int startline = _line;
            int startcol = _column;
            int start = _position;

            while (_position < _input.Length && (Token.AllTokens.ContainsKey(_input.Substring(start, _position - start + 1)) || char.IsPunctuation(_input[_position])))
            {
                _position++;
                _column++;
            }

            string symbol = _input.Substring(start, _position - start);

            if (Token.AllTokens.ContainsKey(symbol))
            {
                return new Token(Token.AllTokens[symbol], symbol, startline, startcol);
            }
            Errors.Add(new LexError($"Invalid token: {symbol}", startline, startcol));
            return new Token(TokenType.Unknown, symbol, startline, startcol);
        }

        //Lee los strings e identifica errores relacionados
        public Token ReadString(TokenType tokenType)
        {
            int startLine = _line;
            int startColumn = _column;
            _position++;
            _column++;
            var value = new StringBuilder();

            while (_position < _input.Length)
            {
                char current = _input[_position];

                if (current == '"')
                {
                    _position++;
                    _column++;
                    break;
                }

                if (current == '\n')
                {
                    HandleUnfinishedStringError(startLine, startColumn);
                    return new Token(TokenType.Unknown, value.ToString(), startLine, startColumn);
                }

                value.Append(current);
                AvancePos();
            }

            if (_position >= _input.Length)
            {
                HandleUnfinishedStringError(startLine, startColumn);
                return new Token(TokenType.Unknown, value.ToString(), startLine, startColumn);
            }

            // Compara el valor leido para devolver el token correspondiente
            string result = value.ToString();
            switch (result)
            {
                case "Oro":
                    return new Token(TokenType.Type, result, startLine, startColumn);
                case "Plata":
                    return new Token(TokenType.Type, result, startLine, startColumn);
                case "Aumento":
                    return new Token(TokenType.Type, result, startLine, startColumn);
                case "Clima":
                    return new Token(TokenType.Type, result, startLine, startColumn);
                case "Lider":
                    return new Token(TokenType.Type, result, startLine, startColumn);
                case "Comunidad del Anillo":
                    return new Token(TokenType.Faction, result, startLine, startColumn);
                case "Mordor":
                    return new Token(TokenType.Faction, result, startLine, startColumn);
                case "None":
                    return new Token(TokenType.Faction, result, startLine, startColumn);
                case "Melee":
                    return new Token(TokenType.Range, result, startLine, startColumn);
                case "Ranged":
                    return new Token(TokenType.Range, result, startLine, startColumn);
                case "Siege":
                    return new Token(TokenType.Range, result, startLine, startColumn);
                default:
                    return new Token(tokenType, result, startLine, startColumn);
            }
        }

        //Simplementa avanza a traves del input dado
        public void AvancePos()
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

        private void HandleUnfinishedStringError(int startLine, int startColumn)
        {
            Errors.Add(new LexError("Unfinished string", startLine, startColumn));
        }
    }
}