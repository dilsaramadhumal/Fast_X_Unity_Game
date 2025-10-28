using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatescript : MonoBehaviour
{
    public Transform spawnpoint1, spawnpoint2;
    public float spawndelay=1.0f;
    public GameObject[] combinedshapes;
    public float shapespeed;
    public float maxshapespeed;
    public float speedincrement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnshapes());
    }

   /* private void FixedUpdate()
    {
        if (shapespeed >= -3f)
        {
            shapespeed -= 0.05f;
        }
    }*/

    private IEnumerator spawnshapes()
    {
        while (true)
        {
            spawnshape();
            yield return new WaitForSeconds(spawndelay);

            if (shapespeed >= maxshapespeed)
            {
                shapespeed -= speedincrement;
            }

        }
    }

    private void spawnshape()
    {
        int randomindex = Random.Range(0, combinedshapes.Length);
        Transform selectedspawnpoint = Random.Range(0, 2) == 0 ? spawnpoint1 : spawnpoint2;
        GameObject spawnedshape = Instantiate(combinedshapes[randomindex], selectedspawnpoint.position, Quaternion.identity);

        Rigidbody2D rb = spawnedshape.GetComponent<Rigidbody2D>(); 
        if (rb != null)
        {
            rb.velocity = new Vector2(0, shapespeed);
        }
    }

}
