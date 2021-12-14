using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public float moveSpeed;
    public GameObject bombObject;
    public float randomCreateMin;
    public float randomCreateMax;
    public int drops = 1;
    public float gravityScale;
    public float massofBomb;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < drops; i++)
        {
            Invoke("CreateBomb", Random.Range(randomCreateMin, randomCreateMax));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
    }

    void CreateBomb()
    {
        GameObject bombobj = Instantiate(bombObject, transform.position, Quaternion.identity);
        Rigidbody2D bombObjrb = bombobj.GetComponent<Rigidbody2D>();
        bombObjrb.gravityScale = gravityScale;
        bombObjrb.mass = massofBomb;
    }
}
