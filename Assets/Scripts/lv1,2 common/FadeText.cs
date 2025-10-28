using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    public TextMeshProUGUI messegetext;
    public float Fadeduration = 0.3f;
    public float Delaybeforefade = 0.1f;

    private Coroutine fadecoroutine;

    private void Awake()
    {
        if (messegetext == null)
        {
            messegetext = GetComponent<TextMeshProUGUI>();
        }
    }

    public void Showmessege(string messege)
    {
        messegetext.text = messege;
        messegetext.color = new Color(messegetext.color.r, messegetext.color.g, messegetext.color.b, 1);
        messegetext.gameObject.SetActive(true);

        if (fadecoroutine != null)
        {
            StopCoroutine(fadecoroutine);
        }

        fadecoroutine = StartCoroutine(fadetextroutine());

    }

    IEnumerator fadetextroutine()
    {
        yield return new WaitForSeconds(Delaybeforefade);
        float startalpha = messegetext.color.a;
        float elapsedtime = 0f;

        while (elapsedtime < Fadeduration)
        {
            elapsedtime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startalpha, 0, elapsedtime / Fadeduration);
            messegetext.color = new Color(messegetext.color.r, messegetext.color.g, messegetext.color.b, newAlpha);
            yield return null;

        }

        messegetext.gameObject.SetActive(false);
             
    }

}
