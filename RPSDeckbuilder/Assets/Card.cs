using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer cardTypeImage;
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;
    public CardType myCardType;
    public CardPicker cardPicker;
    public Combat cardCombat;


    //0 for loss, 1 for tie, 2 for win
    public int compete(CardType otherCard)
    {
        if (myCardType == otherCard) { 
            return 1;
        } else if (myCardType == CardType.rock) {
            if (otherCard == CardType.paper)
            {
                return 0;
            }
        } else if (myCardType == CardType.paper)
        {
            if (otherCard == CardType.scissors)
            {
                return 0;
            }
        } else if (myCardType == CardType.scissors)
        {
            if (otherCard == CardType.rock)
            {
                return 0;
            }
        }
        //if it's not a tie, and it's not a loss, then it's a win
        return 2;
    }

    public void OnMouseDown()
    {
        if (cardPicker != null)
        {
            cardPicker.cardPicked(this.myCardType);
        } else if (cardCombat != null)
        {
            cardCombat.settleCombat(this, compete(cardCombat.pickedEnemyType));
        }
    }

    public void showImageFromType()
    {
        if (myCardType == CardType.rock)
        {
            cardTypeImage.sprite = rockSprite;
        }
        if (myCardType == CardType.paper)
        {
            cardTypeImage.sprite = paperSprite;
        }
        if (myCardType == CardType.scissors)
        {
            cardTypeImage.sprite = scissorsSprite;
        }
    }

    public void setRandomType()
    {
        myCardType = (CardType) Random.Range(0, 3);
        showImageFromType();
    }

}

public enum CardType
{
    rock,
    paper,
    scissors
}