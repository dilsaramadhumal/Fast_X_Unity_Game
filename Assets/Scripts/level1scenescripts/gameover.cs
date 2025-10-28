using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameover : MonoBehaviour
{


    public TextMeshProUGUI yourscore;
    public TextMeshProUGUI highscore;


    //public GameObject gameoverwin;
    /*void Start()
    {
        gameoverwin.SetActive(false);
    }*/

    private void Start()
    {
        /*if (PlayerPrefs.GetInt("highscore") < PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
            highscore.text = "High score - " + PlayerPrefs.GetInt("highscore", 0).ToString();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        yourscore.text = "Your score - " +PlayerPrefs.GetInt("score").ToString();
        highscore.text = "High score - " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
        /*if (PlayerPrefs.GetInt("highscore") < PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
        }*/
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("navigator");
        /*if (PlayerPrefs.GetInt("highscore") < PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
        }*/
    }

    

}
