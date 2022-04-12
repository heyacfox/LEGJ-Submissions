using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public KeyCode MoveRight = KeyCode.D;
    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode RotateUp = KeyCode.W;
    public KeyCode RotateDown = KeyCode.S;
    Rigidbody myRigidbody;
    public float movementSpeed = 1f;
    public float rotateSpeed = 1f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //movement handling
        if (Input.GetKey(MoveRight))
        {
            myRigidbody.AddForce(-transform.right * movementSpeed);
        }
        else if (Input.GetKey(MoveLeft))
        {
            myRigidbody.AddForce(transform.right * movementSpeed * 0.5f);
        }
        //rotation handling
        if (Input.GetKey(RotateUp))
        {
            transform.Rotate(transform.up, -rotateSpeed * Time.deltaTime);
        } else if (Input.GetKey(RotateDown))
        {
            transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
        }

    }
}
