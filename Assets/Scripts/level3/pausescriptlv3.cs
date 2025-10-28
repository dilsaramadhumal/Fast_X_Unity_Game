using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pausescriptlv3 : MonoBehaviour
{
    public GameObject pausewindow;

    public TextMeshProUGUI yourscoret;
    public TextMeshProUGUI highscoret;

    // Start is called before the first frame update
    void Start()
    {
        pausewindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        highscoret.text = "HIGH SCORE " + PlayerPrefs.GetInt("HighScore", 0);
        yourscoret.text = "YOUR SCORE " + PlayerPrefs.GetInt("YourScore", 0);
    }

    public void pausefunc()
    {
        pausewindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumefunc()
    {
        pausewindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void restartfunc()
    {
        SceneManager.LoadScene("level_3");
        Time.timeScale = 1;
    }

    public void exitfunc()
    {
        SceneManager.LoadScene("navigator");
    }
}
