using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//https://www.youtube.com/watch?v=sXTAzcxNqv0
public class Draggable : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    bool nomoredrag;

    GameManager gm;
    AudioSource audioSource;

    public List<Sprite> images;
    public List<AudioClip> sounds;

    Image im;
    float curdissolvetime = 0;
    float dissolvemax = 1;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        canvas = FindObjectOfType<Canvas>();
        im = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        int rindex = Random.Range(0, images.Count);

        im.sprite = images[rindex];
        audioSource.clip = sounds[rindex];
        

    }
    public void DragHandler(BaseEventData data)
    {
        if (!nomoredrag)
        {
            PointerEventData pointerData = (PointerEventData)data;

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);

            transform.position = canvas.transform.TransformPoint(position);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.tag == "goblin")
        {
            
            StartCoroutine(CONSUME());
            if (this.transform.position.x > collision.gameObject.transform.position.x)
            {
                audioSource.panStereo = Random.Range(0, 0.5f);
            } else
            {
                audioSource.panStereo = Random.Range(-0.5f, 0f);
            }
        }
    }

    IEnumerator CONSUME()
    {
        while (curdissolvetime < dissolvemax)
        {
            curdissolvetime += Time.deltaTime;
            im.color = new Color(1f, 1f, 1f, (1 - curdissolvetime / dissolvemax));
            yield return null;
        }
        gm.addEnergy();
        Destroy(this.gameObject);
    }
}
