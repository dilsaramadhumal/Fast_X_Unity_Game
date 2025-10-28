using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float speedMultiplier = 0.5f;
    private GearSystem gearSystem;
    private Vector3 startPos;
    private float spriteHeight;

    void Start()
    {
        gearSystem = FindObjectOfType<GearSystem>();
        startPos = transform.position;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            spriteHeight = sr.bounds.size.y;
    }

    
    void Update()
    {
        float speed = gearSystem.currentSpeed;
        float offset = speed * speedMultiplier * Time.deltaTime;

        transform.position += Vector3.down * offset;

        if(transform.position.y<startPos.y-spriteHeight)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}
