using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pausemenu : MonoBehaviour
{
    public GameObject pausewin;

    public TextMeshProUGUI yourscore;
    public TextMeshProUGUI highscore;

    public void Start()
    {
        pausewin.SetActive(false);
    }

    private void Update()
    {
        //-----------------------
        if (yourscore == null) Debug.LogError("yourscore is NULL!");
        if (highscore == null) Debug.LogError("highscore is NULL!");

        if (yourscore != null)
            yourscore.text = "Your score  " + PlayerPrefs.GetInt("score", 0).ToString();

        if (highscore != null)
            highscore.text = "High score  " + PlayerPrefs.GetInt("highscore", 0).ToString();
        //-----------------------
        //yourscore.text = "Your score  " + PlayerPrefs.GetInt("score",0).ToString();
        //highscore.text = "High score  " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void Resume()
    {
        pausewin.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausewin.SetActive(true);
        if (PlayerPrefs.GetInt("highscore") < PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("navigator");
    }

    public void Restart()
    {
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
        
    }
}
