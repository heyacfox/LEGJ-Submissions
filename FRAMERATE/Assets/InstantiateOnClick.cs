using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiateOnClick : MonoBehaviour
{
    public GameObject prefabToMake;
    public bool mouseStyleDown = true;
    public bool canMove = true;
    public float gravity = 0;
    public float mybounciness = 0.5f;
    public PhysicsMaterial2D noBounce;
    public PhysicsMaterial2D quarterBounce;
    public PhysicsMaterial2D halfBounce;
    public PhysicsMaterial2D mostBounce;
    public PhysicsMaterial2D FullBounce;
    public bool useContinuous = false;
    public float newscale = 1.0f;
    public Transform bigTransform;



    // Update is called once per frame
    void Update()
    {
        //ignore if over ui
        if (EventSystem.current.IsPointerOverGameObject()) return;


       if (mouseStyleDown && Input.GetMouseButtonDown(0))
        {
            Vector2 posToPlace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            handleInstantiation(posToPlace);
        } else if (!mouseStyleDown && Input.GetMouseButton(0))
        {
            Vector2 posToPlace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            handleInstantiation(posToPlace);
        }
    }

    public void onSizeSliderChanged(float newValue)
    {
        newscale = newValue;
    }

    public void onMouseTypeChanged(int selection)
    {
        if (selection == 0)
        {
            mouseStyleDown = true;
        }
        else
        {
            mouseStyleDown = false;
        }
    }

    public void onMovementChanged(bool selection)
    {
        canMove = selection;
    }

    public void onBouncinessChanged(float selection)
    {
        if (selection == 0)
        {
            mybounciness = 0.0f;
        } else if (selection == 1)
        {
            mybounciness = 0.25f;
        }
        else if (selection == 2)
        {
            mybounciness = 0.55f;
        }
        else if (selection == 3)
        {
            mybounciness = 0.75f;
        }
        else if (selection == 4)
        {
            mybounciness = 1f;
        }
    }

    public void onCollisionTypeChanged(int selection)
    {
        if (selection == 0)
        {
            useContinuous = false;
        } else
        {
            useContinuous = true;
        }
    }

    public void onGravityChanged(string selection)
    {
        gravity = float.Parse(selection);
    }

    public void onDeleteAll()
    {
        foreach (Transform t in bigTransform)
        {
            Destroy(t.gameObject);
        }
    }

    public void handleInstantiation(Vector2 placeLocation)
    {
        GameObject createdObject = Instantiate(prefabToMake, placeLocation, Quaternion.identity);
        Rigidbody2D cRigidbody = createdObject.GetComponent<Rigidbody2D>();
        Collider2D cCollider = createdObject.GetComponent<Collider2D>();
        createdObject.transform.parent = bigTransform;

        createdObject.transform.localScale = new Vector3(newscale, newscale, newscale);

        cRigidbody.gravityScale = gravity;
        if (canMove)
        {
            cRigidbody.bodyType = RigidbodyType2D.Dynamic;
        } else
        {
            cRigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        if (mybounciness == 0.0f)
        {
            cCollider.sharedMaterial = noBounce;
        } else if (mybounciness == 0.25f)
        {
            cCollider.sharedMaterial = quarterBounce;
        }
        else if (mybounciness == 0.5f)
        {
            cCollider.sharedMaterial = halfBounce;
        }
        else if (mybounciness == 0.75f)
        {
            cCollider.sharedMaterial = mostBounce;
        }
        else if (mybounciness == 1.0f)
        {
            cCollider.sharedMaterial = FullBounce;
        }

        if (useContinuous)
        {
            cRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }
}
