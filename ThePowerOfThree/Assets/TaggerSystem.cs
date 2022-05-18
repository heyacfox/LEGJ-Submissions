using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggerSystem : MonoBehaviour
{

    public birdmusicer storedBird;
    

    // Update is called once per frame
    void Update()
    {
        if (storedBird == null) return;
        //j drums, k guitar, l base
        if (Input.GetKeyDown(KeyCode.J)) {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we're at a bird
        if (collision.tag == "bird")
        {
            //if we don't have one stored
            if (storedBird == null)
            {
                //if the bird is not
                birdmusicer bm = collision.gameObject.GetComponent<birdmusicer>();
                if (bm.curState != musicerState.leaving)
                {
                    storedBird = bm;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == storedBird)
        {
            storedBird.unselectBird();
        }
    }
}
