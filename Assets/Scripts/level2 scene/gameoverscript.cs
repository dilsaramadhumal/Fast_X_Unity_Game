using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameoverscript : MonoBehaviour
{
    public GameObject gameoverwindow;

    public TextMeshProUGUI yourscoret;
    public TextMeshProUGUI highscoret;


    // Start is called before the first frame update
    void Start()
    {
        gameoverwindow.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoret.text = "HIGH SCORE " + PlayerPrefs.GetInt("highscoret", 0);
        yourscoret.text = "YOUR SCORE " + PlayerPrefs.GetInt("yourscoret", 0);
    }

    public void restartfunc()
    {
        SceneManager.LoadScene("level_2");
        Time.timeScale = 1;
    }

    public void exitfunc()
    {
        SceneManager.LoadScene("navigator");
    }

}
