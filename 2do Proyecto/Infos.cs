/*
Type: Tipo de la carta "Oro", "Plata", "Clima", "Aumento", "Lider"
Name: Nombre de carta
Faction: Faccion de carta. Las cartas de un mismo mazo comparten faccion
Power: Poder. Los Climas, Aumentos y Lideres deben tener Power = 0
Range: array con las franjas jugables de la carta. "Melee", "Ranged", "Siege"
OnActivation: Efectos que se ejecutaran en secuencia cuando se coloque la carta. Propiedades de la invocacion de los efectos:
>Effect: objeto que lleva nombre del efecto a usar (definido anteriormente en effect) y los parametros que recibe.
>Selector: Filtro de las cartas a las que se va a aplicar el efecto (targets). Propiedades:
-Source: de donde se sacan las cartas: "hand", "otherHand", "deck", "otherDeck", "field", "otherField", "parent".
parent  es fuente en el PostAction, su fuente sera la lista de targets que construya el efecto despues del PostAction
-Single: booleano que dice si se va a tomar el primer valor de la busqueda o todas las cartas que cumplan con el predicado
-Predicate: un filtro: La funcion que recibe una carta y devuelve un booleano que dice si se debe tomar o no
>PostAction: Declaracion de efecto. Opcional. Se ejecuta despues de que el primer efecto lo haga (que puede tener otro PostAction).
La propiedad Selector es opcional y si se omite entonces la lista de targets sera la de su efecto padre
*/


card {
    Type: "Oro",
    Name: "Nombre",
    Faction: "Faccion",
    Power: numero,
    Range: ["Melee", "Ranged", "Siege"], 
    OnActivation: [
        {
        Effect:{
            Name: "Damage", //debe ser definido antes
            Amount: x, //parametro que se le pasa al efecto
        }
        Selector:{
            Source: "board",
            Single: false, //por defecto es false
            Predicate: (unit)=>unit.Faction == "Faccion"
        }
        PostAction:{
                Type: "ReturnToDeck",
                Selector:{ //opcional en PostAction. Si se usa se usa el del padre
                            Source: "parent",
                            Single: false,
                            Predicate: (unit) => unit.Power < 1,
                }
        }
    },
    {
        Effect: "Draw" //de escribirse directamente el string este se interpreta como: {Name: "Draw"}
    }
    ]
}


/*
Name: nombre del efecto. Obligatorio
Params: parametro que se le pasa al efecto. Opcional (int, string, bool)
Action: La funcion que ejecuta el efecto y cuyos Params son accesibles dentro del cuerpo de la funcion.Los Params son:
>targets: lista de objetivos. Cada efecto tiene uno o varios objetivos que se declaran en su selector cuando se invoca el efecto
>Context: Contexto del juego. Contiene info sobre el estado del juego. Posee las propiedades:
-TriggerPlayer: devuelve el id del jugador que utilizo el efecto
-Board: devuelve las cartas que esten en el tablero
-HandOfPlayer(player), FieldOfPlayer(player), GraveyardOfPlayer(player) y DeckOfPlayer(player). Devuelven la lista correspondiente del jugador que se les pase como parametro
context.Hand sirve como diminutivo de context.HandOfPlayer(context.TriggerPlayer). Lo mismo con Deck, Field y Graveyard.
Cada carta tiene la propiedad card.Owner que devuelve el id del duenno de la carta
+Propiedades de las listas de cartas accesibles desde el contexto:
-Find(predicate): devuelve las cartas que cumplan con el predicado (funcion que recibe una carta) y devuelve un booleano
-Push(card): agrega carta al tope de la lista
-SendBottom(card): Agrega una carta al fondo de la lista
-Pop(): quita la carta del tope de la lista y la devuelve
-Remove(card): elimina una carta de la lista
-Shuffle(): Mezcla la lista
*/


effect {
    Name: "Damage",
    Params: {
        amount: Number
    }
    Action: (targets, context) => {
        for target in targets {
            i=0;
            while (int++ < amount)
                target.Power -= 1;
        };
    }
}

effect {
    Name: "Draw",
    Action: (targets, context) => {
        topCard = context.Deck.Pop();
        context.Hand.Add(topCard);
        context.Hand.Shuffle();
    }
}

effect {
    Name: "ReturnToDeck",
    Action: (targets, context) => {
        for target in targets {
            owner = targets.Owner;
            deck = context.DeckOfPlayer(owner);
            deck.Push(target);
            deck.Shuffle();
            context.Board.Remove(target);
};
}
}