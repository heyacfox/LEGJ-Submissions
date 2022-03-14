using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipMover : MonoBehaviour
{
    public TMP_Text engineInfo;
    public TrashManager trashManager;

    [Header("thrusterParticles")]
    public ParticleSystem rearThrusterA;
    public ParticleSystem rearThrusterB;

    [Header("Keys")]
    public KeyCode accelerateKey = KeyCode.W;
    public KeyCode turnLeftKey = KeyCode.A;
    public KeyCode turnRightKey = KeyCode.D;
    public KeyCode frontThrusterKey = KeyCode.S;
    public KeyCode tiltUpKey = KeyCode.UpArrow;
    public KeyCode tiltDownKey = KeyCode.DownArrow;
    public KeyCode rotateLeftKey = KeyCode.LeftArrow;
    public KeyCode rotateRightKey = KeyCode.RightArrow;
    public KeyCode fullstop = KeyCode.Space;

    [Header("ThrustLocs")]
    public Transform rearThrustPos;
    public Transform frontThrustPos;
    public Transform leftThrustPos;
    public Transform rightThrustPos;
    public Transform topThrustPos;
    public Transform botThrustPos;
    public Transform rightBotThrustPos;
    public Transform leftBotThrustPos;


    [Header("ThrustMults")]
    public float bigThruster = 10f;
    public float regularthruster = 5f;
    public float smallThruster = 2f;
    public float allThrustMult = 0.1f;


    private Rigidbody myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        var ema = rearThrusterA.emission;
        ema.enabled = false;
        trashManager = FindObjectOfType<TrashManager>();
    }

    private void Update()
    {
        if (Input.GetKey(accelerateKey))
        {
            accelerate();
        } else
        {
            var ema = rearThrusterA.emission;
            ema.enabled = false;
            var emb = rearThrusterB.emission;
            emb.enabled = false;
        }
        if (Input.GetKey(turnLeftKey))
        {
            turnLeft();
        }
        if (Input.GetKey(turnRightKey))
        {
            turnRight();
        }
        if (Input.GetKey(tiltUpKey))
        {
            tiltUp();
        }
        if (Input.GetKey(tiltDownKey))
        {
            tiltDown();
        }
        if (Input.GetKey(rotateRightKey))
        {
            rotateRight();
        }
        if (Input.GetKey(rotateLeftKey))
        {
            rotateLeft();
        }
        if (Input.GetKey(frontThrusterKey))
        {
            frontThruster();
        }
        if (Input.GetKey(fullstop))
        {
            myRigidbody.velocity = Vector3.zero;
            myRigidbody.angularVelocity = Vector3.zero;
        }

        engineInfo.text = "X Vel:" + myRigidbody.velocity.x.ToString("#.00") + "\n" +
            "Y Vel:" + myRigidbody.velocity.y.ToString("#.00") + "\n" +
            "Z Vel:" + myRigidbody.velocity.z.ToString("#.00") + "\n";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "trash")
        {
            Destroy(collision.gameObject);
            trashManager.trashCollected();
        }
    }

    //forward velocity
    void accelerate()
    {
        
        myRigidbody.AddForce(rearThrustPos.forward * allThrustMult * bigThruster, ForceMode.Force);
        var ema = rearThrusterA.emission;
        ema.enabled = true;
        var emb = rearThrusterB.emission;
        emb.enabled = true;
    }

    //turn left
    void turnLeft()
    {
        myRigidbody.AddForceAtPosition(leftThrustPos.forward * allThrustMult * smallThruster, leftThrustPos.position, ForceMode.Force);
    }

    //turn right

    void turnRight()
    {
        myRigidbody.AddForceAtPosition(rightThrustPos.forward * allThrustMult * smallThruster, rightThrustPos.position, ForceMode.Force);
    }

    //rotate left

    void rotateLeft()
    {
        myRigidbody.AddForceAtPosition(leftBotThrustPos.forward * allThrustMult * smallThruster, rightBotThrustPos.position, ForceMode.Force);
    }

    //rotate right
    void rotateRight()
    {
        myRigidbody.AddForceAtPosition(rightBotThrustPos.forward * allThrustMult * smallThruster, leftBotThrustPos.position, ForceMode.Force);
    }

    //tilt up
    void tiltUp()
    {
        myRigidbody.AddForceAtPosition(botThrustPos.forward * allThrustMult * smallThruster, botThrustPos.position, ForceMode.Force);
    }


    //tilt down
    void tiltDown()
    {
        myRigidbody.AddForceAtPosition(topThrustPos.forward * allThrustMult * smallThruster, topThrustPos.position, ForceMode.Force);
    }
    
    void frontThruster()
    {
        myRigidbody.AddForce(frontThrustPos.forward * allThrustMult * regularthruster, ForceMode.Force);
    }


}
