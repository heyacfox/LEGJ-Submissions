using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMover : MonoBehaviour
{
    public float currentSpeed;
    //bigger distance = less speed added to velocity on each add.
    public float parallaxDist;
    Rigidbody2D myRigidbody;
    public float speedReductionPerSecond;
    public float genericMultiplierForEffect = 100f;
    public float maxVel = 4f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float nextVel = myRigidbody.velocity.x + speedReductionPerSecond * Time.deltaTime;
        //if (nextVel >= 0) nextVel = 0;
        //myRigidbody.velocity = new Vector2(nextVel, 0f);
        if (transform.position.x <= -20f)
        {
            transform.position = Vector2.zero;
        }
    }

    public void addSpeed(float moveSpeed)
    {
        /*
        float currentxVel = myRigidbody.velocity.x;
        float nextXvel = currentxVel - (moveSpeed * (1 / parallaxDist) * genericMultiplierForEffect);
        if (nextXvel > maxVel * (1 / parallaxDist) * genericMultiplierForEffect)
        {
            nextXvel = maxVel;
        }
        */
        float forceToAdd = moveSpeed * (1 / parallaxDist) * genericMultiplierForEffect;
        myRigidbody.AddForce(new Vector2(-forceToAdd, 0f));
    }
}
