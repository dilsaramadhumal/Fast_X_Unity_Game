using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemechanism : MonoBehaviour
{
    //----------------variable---------------declaration----------starts--------------------****************************

    public List<Transform> activefallingobjects = new List<Transform>();
    public Transform bottommostobject;

    private identityscripts identity;
    private string topshape;
    private string bottomshape;
    private string selectedcolor;
    private bool bottomselected = false;
    private bool topselected = false;

    public FadeText fadetext;

    public float shakeduration = 0.2f;
    public float shakemagnitude = 0.1f;

    public float colorduration = 0.1f;
    public float scaleduration = 0.3f;

    public float destroydelay = 0.5f;

    private bool isvibrating = false;

    private int scoreval=0;
    private int yourscore;
    private int highscore;
    public TextMeshProUGUI yourscoret;
    public TextMeshProUGUI highscoret;

    //-----------------------------------------variable---------declaration---------------ends-----------***************

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("yourscoret", 0);
    }

    // Update is called once per frame
    void Update()
    {
        updatebottommostobject();

        
        if (yourscore > PlayerPrefs.GetInt("highscoret"))
        {
            PlayerPrefs.SetInt("highscoret", yourscore);
        }
        highscoret.text = "HIGH SCORE " + PlayerPrefs.GetInt("highscoret", 0).ToString();

        PlayerPrefs.SetInt("yourscoret", scoreval);
        yourscoret.text = "YOUR SCORE " + PlayerPrefs.GetInt("yourscoret", 0).ToString();

    }
    //-----------------------handling---------------objects------------**************************************************
    void updatebottommostobject()
    {
        if (activefallingobjects.Count > 0)
        {
            Transform bottomobject = activefallingobjects[0];
            foreach (Transform obj in activefallingobjects)
            {
                if (obj.position.y < bottomobject.position.y)
                {
                    bottomobject = obj;
                }

            }
            bottommostobject = bottomobject;
        }
    }

    public void addobjectstolist(Transform newobject)
    {
        activefallingobjects.Add(newobject);
    }

    public void removeobjectsfromlist(Transform oldobject)
    {
        if (activefallingobjects.Contains(oldobject))
        {
            activefallingobjects.Remove(oldobject);
        }
    }
    //---------------------handling-------------------objects-------------------ends-----*******************************

    //--------------comaparison----------of------objects-------start------------------------****************************
    public void selectbottomhalf(string shape)
    {
        bottomshape = shape;
        identity = bottommostobject.GetComponent<identityscripts>();
        if (bottommostobject != null)
        {
            if (bottomshape == identity.bottomhalf)
            {
                StartCoroutine(scaleeffect(bottommostobject.gameObject));
                bottomselected = true;
            }
            else
            {
                StartCoroutine(vibrateeffect(bottommostobject.gameObject));
            }
        }
    }

    public void selecttophalf(string shape)
    {
        topshape = shape;
        identity = bottommostobject.GetComponent<identityscripts>();

        if(topshape==identity.tophalf && bottomselected == true)
        {
            StartCoroutine(highlighteffect(bottommostobject.gameObject));
            topselected = true;
        }
        else
        {
            StartCoroutine(vibrateeffect(bottommostobject.gameObject));
        }

    }

    public void selectcolor(string color)
    {
        if (!bottomselected || !topselected)
        {
            if (fadetext == null)
            {
                fadetext = GetComponent<FadeText>();
            }
            if (fadetext != null)
            {
                fadetext.Showmessege("Choose the shapes first");
            }
            StartCoroutine(vibrateeffect(bottommostobject.gameObject));
        }

        selectedcolor = color;
        if (topshape != null)
        {
            if (selectedcolor == identity.shapecolor && topselected == true)
            {
                makegreyanddestroy(bottommostobject.gameObject);
                //------scoring-----------------begins----------------------
                scoreval += 1;
                yourscore = scoreval;
                
                

                //yourscoret.text = "YOUR SCORE " +scoreval;
                //--------------scoring--------------------ends-----------------------------
                topshape = null;
                topselected = false;
                bottomselected = false;
            }
            else
            {
                StartCoroutine(vibrateeffect(bottommostobject.gameObject));
            }
        }
        else
        {
            StartCoroutine(vibrateeffect(bottommostobject.gameObject));
            if (fadetext == null)
            {
                fadetext = GetComponent<FadeText>();
            }
            if (fadetext != null)
            {
                fadetext.Showmessege("Choose the shapes first");
            }
        }
        
    }
    //----------------------------comparison-----------of----------------objects---------ends---------------------------


    //-----------------------------functions -------------of--------------effects---------------************************
    IEnumerator vibrateeffect(GameObject obj)
    {
        if (isvibrating) yield break;
        isvibrating = true;

        Vector2 originalposition = obj.transform.position;
        float elapsed = 0.0f;
        while (elapsed < shakeduration)
        {
            float x = Random.Range(-1f, 1f) * shakemagnitude;
            float y = Random.Range(-1.5f, -1f) * shakemagnitude;

            obj.transform.position = new Vector2(originalposition.x + x, originalposition.y + y);
            elapsed += Time.deltaTime;

            yield return null;

        }

        obj.transform.position = originalposition;

        if (isvibrating == true)
        {
            yield return new WaitForSeconds(2.0f);
            isvibrating = false;
        }
        //isvibrating = false;
    }

    IEnumerator scaleeffect(GameObject obj )
    {
        Vector3 originalscale = obj.transform.localScale;
        Vector3 targetscale = originalscale * 1.2f;

        while (obj != null)
        {
            float elapsedtime = 0f;
            while (elapsedtime < scaleduration)
            {
                obj.transform.localScale = Vector3.Lerp(originalscale, targetscale, elapsedtime / scaleduration);
                elapsedtime += Time.deltaTime;
                yield return null;
            }

            elapsedtime = 0f;
            while (elapsedtime < scaleduration)
            {
                obj.transform.localScale = Vector3.Lerp(targetscale, originalscale, elapsedtime / scaleduration);
                elapsedtime += Time.deltaTime;
                yield return null;
            }
        }
    }

    IEnumerator highlighteffect(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        Color originalcolor = sr.color;
        Color highlightcolor = Color.black;

        float elapsedtime = 0f;

        while (elapsedtime < colorduration)
        {
            sr.color = Color.Lerp(originalcolor, highlightcolor, elapsedtime / colorduration);
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        sr.color = originalcolor;

    }

    void makegreyanddestroy(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = Color.grey;
        Destroy(obj, destroydelay);
    }

}
