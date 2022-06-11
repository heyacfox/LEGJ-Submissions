using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonOption : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Button button;
    GameManager gameManager;
    public TMP_Text buttonText;

    public float initialVelocity;
    public float disappearTime = 1f;
    public int isGood1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        button = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        float maxVel = initialVelocity;
        myRigidbody.AddForce(new Vector2(Random.Range(50, initialVelocity),
            Random.Range(50, initialVelocity)));
    }

    public void setupButton(string post, int goodis1)
    {
        buttonText.text = post;
        isGood1 = goodis1;
    }

    public void buttonClicked()
    {
        button.interactable = false;
        StartCoroutine(tweenDown());
        if (isGood1 == 1)
        {
            gameManager.goodAction();
        } else
        {
            gameManager.badAction();
        }
        
    }

    IEnumerator tweenDown()
    {
        float timer = 0;
        while (timer < disappearTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, timer / disappearTime);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
