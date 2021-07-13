using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardType> deckOfCardTypes;

    public void addCardToDeck(CardType cardType)
    {
        deckOfCardTypes.Add(cardType);
    }
}
