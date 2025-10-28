using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttoncontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void intermidiatebutton()
    {
        SceneManager.LoadScene("level_2");
        Time.timeScale = 1;
    }

    public void beginerbutton()
    {
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
    }

    public void advancedbutton()
    {
        SceneManager.LoadScene("level_3");
        Time.timeScale = 1;
    }

    public void mainmenubutton()
    {
        SceneManager.LoadScene("home");
    }

}
