using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float distroydistance = -800f;
    private float fallspeed;
    private GearSystem gearsystem;

    private void Start()
    {
        gearsystem = FindObjectOfType<GearSystem>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (gearsystem != null)
        {
            fallspeed = gearsystem.currentSpeed;
        }

        transform.Translate(Vector3.down * fallspeed * Time.deltaTime);

        if (transform.position.y < -distroydistance)
        {
            Destroy(gameObject);
        }

    }

}
