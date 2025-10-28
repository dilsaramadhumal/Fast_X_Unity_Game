using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject[] shapes;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public float spawndelay = 1.0f;

    public Vector2 shapevelocity;
    public float maxvelo;
    public float veloincrement;

    GameObject spawnedshape;

    void Start()
    {
        StartCoroutine(SpawnShapesCoroutine());
    }

    /*void FixedUpdate()
    {
        int randomindex = Random.Range(0, 16);
        int randomplace = Random.Range(0, 2);

        Transform selectedspawnpoint = Random.Range(0, 2) == 0 ? spawnpoint1 : spawnpoint2;

        if (spawndelay > 100)
        {
            Instantiate(shapes[randomindex], selectedspawnpoint.position, Quaternion.identity);
            spawndelay = 0;
        }

        spawndelay++;
    }*/



    IEnumerator SpawnShapesCoroutine()
    {
        while (true)
        {
            int randomindex = Random.Range(0, shapes.Length);
            Transform selectedspawnpoint = Random.Range(0, 2) == 0 ? spawnpoint1 : spawnpoint2;
            spawnedshape = Instantiate(shapes[randomindex], selectedspawnpoint.position, Quaternion.identity);
            Rigidbody2D rb = spawnedshape.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shapevelocity;
            }
            yield return new WaitForSeconds(spawndelay);

            if (shapevelocity.y >= maxvelo)
            {
                shapevelocity.y -= veloincrement;
            }

        }
    }

}
