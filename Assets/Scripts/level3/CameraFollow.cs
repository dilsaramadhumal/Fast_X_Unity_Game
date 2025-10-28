using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    
    public Transform target;

    

    public float followspeed = 2f;

    private void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, followspeed * Time.deltaTime);
    }

}
