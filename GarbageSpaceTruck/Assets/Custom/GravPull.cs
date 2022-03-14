using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravPull : MonoBehaviour
{
    public Rigidbody shipToAffect;
    public float gravityAmount;
    float initialGravDistance;

    // Update is called once per frame
    void Update()
    {
        initialGravDistance = transform.localScale.x * 3;
        float distanceToShip = Vector3.Distance(transform.position, shipToAffect.transform.position);
        
        float forceEffect = initialGravDistance - distanceToShip / initialGravDistance;
        if (distanceToShip > initialGravDistance)
        {
            forceEffect = 0f;
        }
        Vector3 toPlanet = transform.position - shipToAffect.transform.position;
        shipToAffect.AddForce(toPlanet * gravityAmount);
    }
}
