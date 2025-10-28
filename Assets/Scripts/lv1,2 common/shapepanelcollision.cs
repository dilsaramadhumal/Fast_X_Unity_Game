using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapepanelcollision : MonoBehaviour
{
    public GameObject gameoverwindow;

    void Start()
    {
        gameoverwindow.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShapeTag"))
        {
            Time.timeScale = 0;
            gameoverwindow.SetActive(true);
        }
    }
}