using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool IsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        Debug.Log(gameObject.name + "zrotation = " + transform.rotation.eulerAngles.z);
        if (Mathf.Abs(transform.rotation.eulerAngles.z) > 80f && Mathf.Abs(transform.rotation.eulerAngles.z) < 290f)
        {
            IsDead = true;
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            Destroy(this.gameObject, 3f);
        } 
    }
}
