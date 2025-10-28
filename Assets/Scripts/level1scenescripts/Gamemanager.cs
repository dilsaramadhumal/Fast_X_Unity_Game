using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public List<Transform> activefallingobjeccts = new List<Transform>();
    public Transform bottommostobjject;

    private prefabidentity prefidentity;
    public FadeText fadetext;

    private string selectedshape;
    private bool shapeselected = false;
    private string selectedcolor;
    private bool colorselected=false;

    public float destroydelay = 0.5f;

    public float shakeduration = 0.2f;
    public float shakemagnitude = 0.1f;

    private int scoreval = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    private void Start()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    void Update()
    {
        updatebottommostobj();
        if (PlayerPrefs.GetInt("highscore",0) < PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
        }
        highscore.text = "HIGHSCORE " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }
//----------------object------------array----------------handling--------------starts------------------------
    void updatebottommostobj()
    {
        if (activefallingobjeccts.Count > 0)
        {
            Transform botttomobject = activefallingobjeccts[0];
            foreach (Transform obj in activefallingobjeccts)
            {
                if(obj.position.y < botttomobject.position.y)
                {
                    botttomobject = obj;
                }
            }
            bottommostobjject = botttomobject;
        }
        
    }
    
    public void addobjectstolist(Transform newobject)
    {
        activefallingobjeccts.Add(newobject);
    }

    public void removeobjectsfromlist(Transform oldobject)
    {
        if (activefallingobjeccts.Contains(oldobject))
        {
            activefallingobjeccts.Remove(oldobject);
        }
    }
//----------------------------objects--------arrray---------handling---------------ends----------------------

//---------------------matching--------------logic-----------------starts------------------------------------
    public void SelectShape(string shape)
    {
        selectedshape = shape;
        selectedcolor = null;
        HighlightShape();
    }

    public void SelectColor(string color)
    {
        if (string.IsNullOrEmpty(selectedshape))
        {
            if (fadetext == null)
            {
                fadetext = GetComponent<FadeText>();
            }
            if (fadetext != null) 
                {
                    fadetext.Showmessege("Choose a shape first");
                }
            colorselected = false;
            StartCoroutine(Shakeobject(bottommostobjject.gameObject));
        }

        selectedcolor = color;
        HighlightColor();

        //------------scoring begins-------------------------
        if (colorselected == true)
        {
            scoreval += 1;
            score.text = "YOUR SCORE " + scoreval;
            PlayerPrefs.SetInt("score", scoreval);
        }
        //---------------------scoring ends------------------
        
    }

 //------------------------------effects----------handling-----------------lv1---------------starts----------
    //----------------------------------------shapehighlight-------------------
    void HighlightShape()
    {
        prefidentity = bottommostobjject.GetComponent<prefabidentity>();
        if (bottommostobjject != null)
        {
            if(selectedshape == prefidentity.objectname)
            {
                Applyshapehighlight(bottommostobjject.gameObject);
                shapeselected = true;
            }
            else
            {
                shapeselected = false;
                StartCoroutine(Shakeobject(bottommostobjject.gameObject));
                
            }
        }
    }

    void Applyshapehighlight(GameObject obj)
    {
        StartCoroutine(ScalUpDown(obj));
    }

    IEnumerator ScalUpDown(GameObject obj)
    {
        Vector2 originalscale = obj.transform.localScale;
        Vector2 targetscale = originalscale * 1.2f;

        while (string.IsNullOrEmpty(selectedcolor))
        {
            float scale = Mathf.PingPong(Time.time * 2, 0.5f);
            obj.transform.localScale = Vector3.Lerp(originalscale, targetscale, scale);
            yield return null;
        }
        obj.transform.localScale = originalscale;
    }

    //-----------------------------------------colorhighlight-------------------
    void HighlightColor()
    {
        if(bottommostobjject!= null && prefidentity != null)
        {
            if (shapeselected == true && selectedcolor == prefidentity.objectcolor)
            {
                Applycolorhighlight(bottommostobjject.gameObject);
                Destroy(bottommostobjject.gameObject, destroydelay);
                colorselected = true;
                selectedshape = null;
                selectedcolor = null;
            }
            else
            {
                StartCoroutine(Shakeobject(bottommostobjject.gameObject));
                colorselected = false;
                selectedcolor = null;
            }
        }
        else
        {
            colorselected = false;
        }
        
    }

    void Applycolorhighlight(GameObject obj)
    {
        StopCoroutine(ScalUpDown(obj));
        Renderer renderer = obj.GetComponent<Renderer>();
        if(renderer!= null)
        {
            renderer.material.color = Color.gray;
        }
    }

    //----------------------------------------------------------shakingeffect--------
    IEnumerator Shakeobject(GameObject obj)
    {
        Vector2 originalposition = obj.transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeduration)
        {
            float x = Random.Range(-1f, 1f) * shakemagnitude;
            float y = Random.Range(-1f, 1f) * shakemagnitude;

            obj.transform.position = new Vector2(originalposition.x + x, originalposition.y + y);
            elapsed += Time.deltaTime;

            yield return null;
        }

        obj.transform.position = originalposition;

    }

}
