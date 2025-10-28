using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChase : MonoBehaviour
{

    public Transform carTransform;
    public Slider enemyDistanceBar;
    public float baseChaseSpeed = 10f;
    public float maxDistance = 240f;
    public float activationDelay = 0f; // Delay before chase starts
    public float chaseThreshold = 45f; // 45% of car top speed------------ changed here 0.45f --> 45f

    private float enemyY;
    private float chaseTimer = 0f;
    private bool isChasing = false;
    private bool isGameOver = false;

    private GearSystem gearSystem;
    //private ScoreManager scoreManager;

    void Start()
    {
        gearSystem = FindObjectOfType<GearSystem>();
        //scoreManager = FindObjectOfType<ScoreManager>();

        enemyY = carTransform.position.y - 240f;
        transform.position = new Vector3(transform.position.x, enemyY, transform.position.z);
    }
    
    void FixedUpdate()
    {
        if (isGameOver) return;

        float currentSpeed = gearSystem.currentSpeed;

        if (currentSpeed < chaseThreshold)
        {
            chaseTimer += Time.deltaTime;
            isChasing = true;
        }
        else
        {
            chaseTimer = 0f;
            isChasing = false;
        }

        if (isChasing)
        {
            float chaseSpeed = baseChaseSpeed * (100f - currentSpeed); // slower if you're slightly fast
            enemyY += chaseSpeed *0.5f* Time.deltaTime;
        }
        else
        {
            // Retreat slightly (makes it feel fair)
            float retreatSpeed = baseChaseSpeed * (currentSpeed - chaseThreshold);
            enemyY -= retreatSpeed * Time.deltaTime;
            enemyY = Mathf.Max(enemyY, carTransform.position.y - 240f);
        }

        transform.position = new Vector3(transform.position.x, enemyY, transform.position.z);

        // Update UI bar
        float distance = carTransform.position.y - enemyY;
        float percent = Mathf.Clamp01(distance / maxDistance);
        enemyDistanceBar.value = 1f - percent;

        if (distance <= 30f)
        {
            //isGameOver = true;
            //scoreManager.Gameover();
        }
    }
}

