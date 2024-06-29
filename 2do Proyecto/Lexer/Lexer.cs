public static class Lexer
{
    private static LexicalAnalyzer? __LexicalProcess;
    public static LexicalAnalyzer LexicalAnalyzer
    {
        get
        {
            if (__LexicalProcess == null)
            {
                __LexicalProcess = new LexicalAnalyzer();

                __LexicalProcess.Operators["+"] = TokenValues.Add;
                __LexicalProcess.Operators["*"] = TokenValues.Mul;
                __LexicalProcess.Operators["-"] = TokenValues.Sub;
                __LexicalProcess.Operators["/"] = TokenValues.Div;
                __LexicalProcess.Operators["="] = TokenValues.Igual;

                __LexicalProcess.Operators[","] = TokenValues.Coma;
                __LexicalProcess.Operators[";"] = TokenValues.PuntoComa;
                __LexicalProcess.Operators["("] = TokenValues.ParentAbierto;
                __LexicalProcess.Operators[")"] = TokenValues.ParentCerrado;
                __LexicalProcess.Operators["{"] = TokenValues.LlaveAbierta;
                __LexicalProcess.Operators["}"] = TokenValues.LlaveCerrada;

                __LexicalProcess.KeyWords["Name"]         = TokenValues.Nombre;
                __LexicalProcess.KeyWords["Description"]  = TokenValues.Description;
                __LexicalProcess.KeyWords["Faction"]       = TokenValues.Faccion;
                __LexicalProcess.KeyWords["Power"]      = TokenValues.Poder;
                __LexicalProcess.KeyWords["Frange"]     = TokenValues.Franja;
                __LexicalProcess.KeyWords["Rank"]    = TokenValues.Rango;
                __LexicalProcess.KeyWords["Lider"]   = TokenValues.EsLider;                

                __LexicalProcess.Texts["\""] = "\"";
            }

            return __LexicalProcess;
        }
    }
}