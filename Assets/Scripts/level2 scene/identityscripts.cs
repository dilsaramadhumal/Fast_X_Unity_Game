using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class identityscripts : MonoBehaviour
{
    public string objectnname;
    public string tophalf;
    public string bottomhalf;
    public string shapecolor;

    gamemechanism mechanic;

    // Start is called before the first frame update
    void Start()
    {
        mechanic = FindObjectOfType<gamemechanism>();
        if (mechanic != null)
        {
            mechanic.addobjectstolist(transform);
        }
    }

    private void OnDestroy()
    {
        mechanic.removeobjectsfromlist(transform);
    }
}
