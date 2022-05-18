using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class birdmusicer : MonoBehaviour
{
    public TMP_Text messageText;
    public TMP_Text nameText;
    public SpriteRenderer highlighter;
    public musicerState curState;

    public Color drummerColor = Color.yellow;
    public Color guitarColor = Color.red;
    public Color bassColor = Color.blue;
    public Color leavingColor = Color.green;
    
    public string storedMessage;
    public string musicianName;
    public musicianType mType;

    public float writeSpeed = 0.05f;
    public bool tagged = false;
    public musicianType taggedByPlayerAs;
    

    public void setupMusicer(string message, string name, musicianType musicType)
    {
        mType = musicType;
        storedMessage = message;
        musicianName = name;
        nameText.text = name;
        messageText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("displayMessageOverTime");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hideMessage();
        }   
    }

    IEnumerator displayMessageOverTime()
    {
        int chars = storedMessage.Length;
        int curDisplay = 0;
        while (curDisplay < chars)
        {
            messageText.text = messageText.text + storedMessage.Substring(curDisplay, 1);
            curDisplay++;
            yield return new WaitForSeconds(writeSpeed);
            //beep noise
        }
    }

    public void hideMessage()
    {
        messageText.text = "";
        StopAllCoroutines();    
    }

    public void enterIdle()
    {
        curState = musicerState.idle;
    }

    public void enterWalking()
    {
        curState = musicerState.walking;
    }

    public void enterLeaving()
    {
        curState = musicerState.leaving;
    }

    public void enterTalking()
    {
        curState = musicerState.talking;
    }

    public void selectBird()
    {
        if (!tagged)
        {
            highlighter.enabled = true;
            highlighter.color = Color.white;
        }
    }

    public void unselectBird()
    {

    }

    public void setTag(musicianType type)
    {
        mType = type;
        if (mType == musicianType.drummer)
        {
            highlighter.color = drummerColor;
        } else if (mType == musicianType.guitarist)
        {
            highlighter.color = guitarColor;
        } else if (mType == musicianType.bassist)
        {
            highlighter.color = bassColor;
        }
        highlighter.enabled = true;
        tagged = true;
        taggedByPlayerAs = type;
    }

}

public enum musicianType
{
    drummer,
    guitarist,
    bassist
}

public enum musicerState
{
    idle,
    walking,
    talking,
    leaving
}
