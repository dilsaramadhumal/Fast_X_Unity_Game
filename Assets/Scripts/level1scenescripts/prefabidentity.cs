using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabidentity : MonoBehaviour
{
    public string objectname;
    public string objectcolor;

    Gamemanager gamemanager;


    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();

        if (gamemanager != null)
        {
            gamemanager.addobjectstolist(transform);
        }

    }

    private void OnDestroy()
    {
        if (gamemanager != null)
        {
            gamemanager.removeobjectsfromlist(transform);
        }
    }

}
