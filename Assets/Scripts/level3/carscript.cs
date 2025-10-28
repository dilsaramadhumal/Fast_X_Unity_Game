using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class carscript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GearSystem gearsystem;
    public GameObject gameoverwindow;
    private CarSideMovement carsidemovement;

    float speed;

    //for scoring....
    public TextMeshProUGUI yourscore;
    //private float survivalTime = 0f;
    public float score=0f;
    public float scoremultiplier;
    public int scorenormalizer;

    void Start()
    {
        carsidemovement = FindObjectOfType<CarSideMovement>();
        gearsystem = FindObjectOfType<GearSystem>();
        rb = GetComponent<Rigidbody2D>();
        //PlayerPrefs.DeleteAll();
        
    }

    private void FixedUpdate()
    {
        speed = gearsystem.currentSpeed;

        Vector2 newpos = transform.position;

        if(carsidemovement.canMoveLeft && carsidemovement.goLeft)
        {
            newpos.x += -carsidemovement.sideMoveSpeed*Time.deltaTime;
        }
        if(carsidemovement.canMoveRight && carsidemovement.goright)
        {
            newpos.x += carsidemovement.sideMoveSpeed * Time.deltaTime;
        }

        transform.position = newpos;



        //for scoring....
        /*survivalTime += (speed*scoremultiplier)/scorenormalizer;

        score += (int)Mathf.Sqrt(survivalTime);*/

        score += 0.02f*speed*scoremultiplier;

        yourscore.text = "Your Score " + score.ToString("F0");
        PlayerPrefs.SetInt("YourScore", (int)score);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Time.timeScale = 0;
            gameoverwindow.SetActive(true);

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
            }
            

        }
        PlayerPrefs.Save();
    }

}
