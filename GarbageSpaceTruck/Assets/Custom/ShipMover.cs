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
    public ParticleSystem leftThruster;
    public ParticleSystem leftBotThruster;
    public ParticleSystem rightThruster;
    public ParticleSystem rightBotThruster;
    public ParticleSystem frontThruster;
    public ParticleSystem topThruster;
    public ParticleSystem botThruster;

    [Header("Keys")]
    public KeyCode accelerateKey = KeyCode.W;
    public KeyCode turnLeftKey = KeyCode.A;
    public KeyCode turnRightKey = KeyCode.D;
    public KeyCode frontThrusterKey = KeyCode.S;
    //INVERTED CONTROLLS
    public KeyCode tiltUpKey = KeyCode.DownArrow;
    public KeyCode tiltDownKey = KeyCode.UpArrow;
    public KeyCode rotateLeftKey = KeyCode.RightArrow;
    public KeyCode rotateRightKey = KeyCode.LeftArrow;
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
        var emb = rearThrusterB.emission;
        emb.enabled = false;

        var e = leftThruster.emission;
        e.enabled = false;
        e = rightThruster.emission;
        e.enabled = false;
        e = rightBotThruster.emission;
        e.enabled = false;
        e = leftBotThruster.emission;
        e.enabled = false;
        e = topThruster.emission;
        e.enabled = false;
        e = botThruster.emission;
        e.enabled = false;
        e = frontThruster.emission;
        e.enabled = false;


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
        } else
        {
            var e = leftThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(turnRightKey))
        {
            turnRight();
        } else
        {
            var e = rightThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(tiltUpKey))
        {
            tiltUp();
        } else
        {
            var e = botThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(tiltDownKey))
        {
            tiltDown();
        } else
        {
            var e = topThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(rotateRightKey))
        {
            rotateRight();
        } else
        {
            var e = leftBotThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(rotateLeftKey))
        {
            rotateLeft();
        } else
        {
            var e = rightBotThruster.emission;
            e.enabled = false;
        }


        if (Input.GetKey(frontThrusterKey))
        {
            frontThrusterForce();
        } else
        {
            var e = frontThruster.emission;
            e.enabled = false;
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
        var e = leftThruster.emission;
        e.enabled = true;
    }

    //turn right

    void turnRight()
    {
        myRigidbody.AddForceAtPosition(rightThrustPos.forward * allThrustMult * smallThruster, rightThrustPos.position, ForceMode.Force);
        var e = rightThruster.emission;
        e.enabled = true;
    }

    //rotate left

    void rotateLeft()
    {
        myRigidbody.AddForceAtPosition(leftBotThrustPos.forward * allThrustMult * smallThruster, rightBotThrustPos.position, ForceMode.Force);
        var e = rightBotThruster.emission;
        e.enabled = true;
    }

    //rotate right
    void rotateRight()
    {
        myRigidbody.AddForceAtPosition(rightBotThrustPos.forward * allThrustMult * smallThruster, leftBotThrustPos.position, ForceMode.Force);
        var e = leftBotThruster.emission;
        e.enabled = true;
    }

    //tilt up
    void tiltUp()
    {
        myRigidbody.AddForceAtPosition(botThrustPos.forward * allThrustMult * smallThruster, botThrustPos.position, ForceMode.Force);
        var e = botThruster.emission;
        e.enabled = true;
    }


    //tilt down
    void tiltDown()
    {
        myRigidbody.AddForceAtPosition(topThrustPos.forward * allThrustMult * smallThruster, topThrustPos.position, ForceMode.Force);
        var e = topThruster.emission;
        e.enabled = true;
    }
    
    void frontThrusterForce()
    {
        myRigidbody.AddForce(frontThrustPos.forward * allThrustMult * regularthruster, ForceMode.Force);
        var e = frontThruster.emission;
        e.enabled = true;
    }


}
