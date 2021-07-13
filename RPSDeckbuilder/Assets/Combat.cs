using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Combat : MonoBehaviour
{
    public Deck playerDeck;
    public GameObject cardPrefab;
    public List<CardType> playerDeckCopy;
    public List<CardType> playerHand;

    public Transform handSlotA;
    public Transform handSlotB;
    public Transform handSlotC;
    public Transform enemySlot;

    public CardType pickedEnemyType;
    public int playerScore;

    public Transform UIAtBeginning;
    public Transform UIAtEnd;

    public TMP_Text score;
    public TMP_Text decksize;

    public AudioClip cardSelectSound;
    public AudioClip startCombatSound;
    AudioSource audioSource;

    public void Start()
    {
        score.text = "";
        decksize.text = "";
        audioSource = GetComponent<AudioSource>();
        
    }

    public void startCombat()
    {
        audioSource.clip = startCombatSound;
        audioSource.Play();
        playerDeckCopy = new List<CardType>(playerDeck.deckOfCardTypes);
        addFromDeckToHand();
        addFromDeckToHand();
        addFromDeckToHand();
        setHandCardLocations();
        pickEnemyCard();
        UIAtBeginning.gameObject.SetActive(false);
        score.text = "Your Score: " + playerScore;
        decksize.text = "Cards Remaining: " + playerDeckCopy.Count;
    }

    public void settleCombat(Card selectedCard, int result)
    {
        audioSource.clip = cardSelectSound;
        audioSource.Play();
        playerHand.Remove(selectedCard.myCardType);
        Destroy(selectedCard);
        playerScore += result;
        score.text = "Your Score: " + playerScore;
        if (playerDeckCopy.Count > 0)
        {
            addFromDeckToHand();
            decksize.text = "Cards Remaining: " + playerDeckCopy.Count;
        }
        if (playerHand.Count > 0)
        {
            
            setHandCardLocations();
            pickEnemyCard();
        } else
        {
            Card[] allCards = FindObjectsOfType<Card>();
            foreach (Card c in allCards)
            {
                Destroy(c.gameObject);
            }
            Debug.Log("Game is over");
            UIAtEnd.gameObject.SetActive(true);
        }
    }

    public void addFromDeckToHand()
    {
        int randomIndexPick = Random.Range(0, playerDeckCopy.Count);
        playerHand.Add(playerDeckCopy[randomIndexPick]);
        playerDeckCopy.RemoveAt(randomIndexPick);
    }

    public void pickEnemyCard()
    {
        GameObject cardeObj = Instantiate(cardPrefab, enemySlot.position, Quaternion.identity);
        cardeObj.GetComponent<Card>().setRandomType();
        cardeObj.GetComponent<SpriteRenderer>().color = Color.red;
        pickedEnemyType = cardeObj.GetComponent<Card>().myCardType;
    }

    public void setHandCardLocations()
    {
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card c in allCards)
        {
            Destroy(c.gameObject);
        }

        if (playerHand.Count >= 1)
        {
            GameObject card1Obj = Instantiate(cardPrefab, handSlotA.position, Quaternion.identity);
            card1Obj.GetComponent<Card>().cardCombat = this;
            
            card1Obj.GetComponent<Card>().myCardType = playerHand[0];
            card1Obj.GetComponent<Card>().showImageFromType();
        } 
        if (playerHand.Count >= 2)
        {
            GameObject card2Obj = Instantiate(cardPrefab, handSlotB.position, Quaternion.identity);
            card2Obj.GetComponent<Card>().cardCombat = this;
            
            card2Obj.GetComponent<Card>().myCardType = playerHand[1];
            card2Obj.GetComponent<Card>().showImageFromType();
        } 
        if (playerHand.Count == 3)
        {
            GameObject card3Obj = Instantiate(cardPrefab, handSlotC.position, Quaternion.identity);
            card3Obj.GetComponent<Card>().cardCombat = this;
            
            card3Obj.GetComponent<Card>().myCardType = playerHand[2];
            card3Obj.GetComponent<Card>().showImageFromType();
        }
    }

    public void cardSelectedFromHand()
    {

    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }


}
