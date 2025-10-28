using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    private float spawnInterval = 2f;
    private bool spawnFromLeft = true;


    private GearSystem gearsystem;

    // Start is called before the first frame update
    void Start()
    {
        gearsystem = FindObjectOfType<GearSystem>();
        StartCoroutine(SpawnRoutine());
    }

    private void FixedUpdate()
    {
        float speed = gearsystem.currentSpeed;

        if (speed > 60f)
        {
            spawnInterval = Random.Range(1.5f, 2.5f);
        }
        else if(speed>40f)
        {
            spawnInterval = Random.Range(2.5f, 3f);
        }
        else if(speed>30f)
        {
            spawnInterval = Random.Range(3f, 4f);
        }
        else if (speed > 20f)
        {
            spawnInterval = Random.Range(4.5f, 5.5f);
        }
        else if (speed > 15f)
        {
            spawnInterval = Random.Range(5.5f, 6.5f);
        }
        else if (speed > 10f)
        {
            spawnInterval = 7f;
        }

        //spawnInterval = 3f;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);


            GameObject something = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];

            Transform spawnPoint = spawnFromLeft ? leftSpawnPoint : rightSpawnPoint;
            GameObject obs = Instantiate(something, spawnPoint.position, Quaternion.identity);

            //float carSpeed = gearsystem.currentSpeed;
            //obs.GetComponent<Obstacle>().Init(baseFallSpeed + carSpeed);

            int randpoint = Random.Range(0, 2);
            if (randpoint == 0)
            {
                spawnFromLeft = true;
            }
            else
            {
                spawnFromLeft = false;
            }
            //spawnFromLeft = !spawnFromLeft;
        }

        
    }
}
