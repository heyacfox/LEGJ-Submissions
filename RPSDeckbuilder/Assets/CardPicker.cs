using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardPicker : MonoBehaviour
{
    public Deck deck;
    public GameObject cardPrefab;
    public Combat combat;
    public int totalPicksAllowed;
    public TMP_Text picksRemaining;
    AudioSource audioSource;
    public AudioClip cardSelected;
    
    

    public void cardPicked(CardType cardType)
    {
        audioSource.clip = cardSelected;
        audioSource.Play();
        deck.addCardToDeck(cardType);
        if (deck.deckOfCardTypes.Count < totalPicksAllowed)
        {
            picksRemaining.text = $"Picks Remaining: {totalPicksAllowed - deck.deckOfCardTypes.Count}";
            showNewCardSelection();
        }
        else
            
        {
            picksRemaining.text = "";
            startCombatRounds();
        }
    }

    public void startCombatRounds()
    {
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card c in allCards)
        {
            Destroy(c.gameObject);
        }
        combat.startCombat();
    }


    private void Start()
    {
        showNewCardSelection();
        picksRemaining.text = $"Picks Remaining: {totalPicksAllowed}";
        audioSource = GetComponent<AudioSource>();
    }


    public void showNewCardSelection()
    {
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card c in allCards)
        {
            Destroy(c.gameObject);
        }
        GameObject card1Obj = Instantiate(cardPrefab, this.transform.position - new Vector3(1.5f, 0), Quaternion.identity);
        card1Obj.GetComponent<Card>().cardPicker = this;
        card1Obj.GetComponent<Card>().setRandomType();
        GameObject card2Obj = Instantiate(cardPrefab, this.transform.position + new Vector3(1.5f, 0), Quaternion.identity);
        card2Obj.GetComponent<Card>().cardPicker = this;
        card2Obj.GetComponent<Card>().setRandomType();
    }
}
