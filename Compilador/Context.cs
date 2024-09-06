using Bops;
using XP;
using Tookeen;
using Tookeen2;

    namespace Cont
    {    
    public class Context
    {
        // Diccionarios para variables y funciones
        private readonly Dictionary<string, object> _variables = new Dictionary<string, object>();
        private readonly Dictionary<string, FunctionDeclarationExpression> _functions = new Dictionary<string, FunctionDeclarationExpression>();

        // Propiedades para el estado del juego
        public static Context Current { get; } = new Context();
        public int TriggerPlayer { get; } // Jugador que desencadenó el efecto
        public List<ICard> Board { get; } // Todas las cartas en el tablero

        // Diccionarios para manos, campos, cementerios y mazos de los jugadores
        private Dictionary<int, List<ICard>> _hands;
        private Dictionary<int, List<ICard>> _fields;
        private Dictionary<int, List<ICard>> _graveyards;
        private Dictionary<int, List<ICard>> _decks;

        // Constructor por defecto
        public Context() {}

        // Constructor con parámetros para inicializar el estado del juego
        public Context(int triggerPlayer, List<ICard> board, Dictionary<int, List<ICard>> hands,
                    Dictionary<int, List<ICard>> fields, Dictionary<int, List<ICard>> graveyards,
                    Dictionary<int, List<ICard>> decks)
        {
            TriggerPlayer = triggerPlayer;
            Board = board;
            _hands = hands;
            _fields = fields;
            _graveyards = graveyards;
            _decks = decks;
        }

        // Métodos para gestión de variables
        public void SetVariable(string name, object value) => _variables[name] = value;

        public object GetVariable(string name) =>
            _variables.TryGetValue(name, out var value) ? value : throw new Exception($"Runtime error: Variable '{name}' not found.");

        // Métodos para gestión de funciones
        public void SetFunction(string name, FunctionDeclarationExpression function) => _functions[name] = function;

        public FunctionDeclarationExpression GetFunction(string name) =>
            _functions.TryGetValue(name, out var function) ? function : null;

        // Métodos para obtener el estado del juego de un jugador específico
        public List<ICard> HandOfPlayer(int playerId) =>
            _hands.ContainsKey(playerId) ? _hands[playerId] : new List<ICard>();

        public List<ICard> FieldOfPlayer(int playerId) =>
            _fields.ContainsKey(playerId) ? _fields[playerId] : new List<ICard>();

        public List<ICard> GraveyardOfPlayer(int playerId) =>
            _graveyards.ContainsKey(playerId) ? _graveyards[playerId] : new List<ICard>();

        public List<ICard> DeckOfPlayer(int playerId) =>
            _decks.ContainsKey(playerId) ? _decks[playerId] : new List<ICard>();
    }
}