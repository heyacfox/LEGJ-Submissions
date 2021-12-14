using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;
    public Rigidbody2D blowerRigidbody;
    public AreaEffector2D ae2d;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Horizontal2 = Input.GetAxisRaw("Horizontal2");

        myRigidbody.velocity = new Vector2(Horizontal * moveSpeed, 0f);
        blowerRigidbody.angularVelocity = Horizontal2 * rotateSpeed;
        //ae2d.forceAngle = blowerRigidbody.transform.roa


    }
}
