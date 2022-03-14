using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform cameraTarget;

    public float followSpeed = 1f;
    public float rotateSpeed = 1f;

    //as distance increases, follow speed needs to increase

    // Update is called once per frame
    void Update()
    {
        float newFollowSpeed = Vector3.Distance(transform.position, cameraTarget.position) * followSpeed;
        float newRotateSpeed = Quaternion.Angle(transform.rotation, cameraTarget.rotation) * rotateSpeed;
        
        transform.position = Vector3.MoveTowards(transform.position, cameraTarget.position, Time.deltaTime * newFollowSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraTarget.rotation, Time.deltaTime * newRotateSpeed);
    }
}
