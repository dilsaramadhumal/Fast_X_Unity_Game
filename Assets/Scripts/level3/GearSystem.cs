using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearSystem : MonoBehaviour
{
    //for gear and stuff
    public Slider speedbar;
    public Button gear1Btn, gear2Btn, gear3Btn, gear4Btn;

    public float currentSpeed = 0f;
    private float maxspeed = 100f;
    private int currentgear = 1;

    private float[] gearspeedlimits = { 15f, 35f, 60f, 100f };
    public float[] accelarationrates = { 5f, 4f, 3f, 2f };
    public float breakrate = 10f;


    //breaking
    public Button breakBtn;
    private bool isBreaking = false;
    public Image speedBarFill;
    private bool isBlinking = false;
    private float blinkTimer = 0f;
    public float blinkDuration = 0.5f;
    public float blinkwait = 0.25f;

    private Color usualcolor = new Color(255f / 255f, 129f / 255f, 102f / 255f);

    //speedprogressbar
    //public UnityEngine.UI.Image speedBarImage;

    //private Coroutine blinkCoroutine = null;
    public float[] gearThresholds = { 15f, 35f, 60f, 100f};

    void Start()
    {
        //breaking
        breakBtn.gameObject.AddComponent<BrakeHoldDetector>().Init(this);

        //gear and stuff
        //Setgear(1);

        gear1Btn.onClick.AddListener(() => Setgear(1));
        gear2Btn.onClick.AddListener(() => Setgear(2));
        gear3Btn.onClick.AddListener(() => Setgear(3));
        gear4Btn.onClick.AddListener(() => Setgear(4));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gear and stuff
        float gearMaxspeed = gearspeedlimits[currentgear - 1];
        

        UpdateGearButtons();

        //breakiing
        if(!isBreaking && currentSpeed < gearMaxspeed)
        {
            currentSpeed += accelarationrates[currentgear - 1] * Time.deltaTime*2;
            currentSpeed = Mathf.Min(currentSpeed, gearMaxspeed);
        }
        if (isBreaking)
        {
            currentSpeed -= breakrate * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }

        speedbar.value = currentSpeed;

        if (Mathf.Approximately(currentSpeed, gearMaxspeed))
        {
            BlinkRedBar();
        }
        else
        {
            //isBlinking = false;
            speedBarFill.color = usualcolor;
        }

        //redblink
        //float maxForGear = gearThresholds[currentgear - 1];
        /*if (currentSpeed >= maxForGear)
        {
            if (!isBlinking)
            {
                blinkCoroutine = StartCoroutine(BlinkSpeedBar());
            }
        }
        else
        {
            if (isBlinking)
            {
                StopCoroutine(blinkCoroutine);
                speedBarFill.color = Color.white;//---------------------------------------
                isBlinking = false;
            }
        }*/
    }
    //------------------------************************END OF UPDATE FUNCTION******************--------------------------

    //gear and stuff
    void Setgear(int gear)
    {
        //if (Mathf.Abs(gear - currentgear) > 1) return;
        currentgear = gear;
    }

    void UpdateGearButtons()
    {
        gear1Btn.interactable = currentgear == 2;
        gear2Btn.interactable = currentgear == 1 || currentgear==3;
        gear3Btn.interactable = currentgear == 2 || currentgear == 4;
        gear4Btn.interactable = currentgear == 3;
    }

    public float GetSpeedPercent()
    {
        return currentSpeed / maxspeed;
    }

    public int GetCurrentGear()
    {
        return currentgear;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    //---------------------*****************dont know what is this for**************----------------------------
    /*public void ReduceSpeed( float amount)
    {
        currentSpeed = Mathf.Max(0, currentSpeed - amount);
        speedbar.value = currentSpeed;
    }*/
    //---------------------*****************dont know what is this for**************----------------------------

    //breaking
    public void StartBreak()
    {
        isBreaking = true;
    }

    public void StopBreak()
    {
        isBreaking = false;
    }

    public void BlinkRedBar()
    {
        isBlinking = true;
        blinkTimer += Time.deltaTime;

        if (blinkTimer >= blinkDuration)
        {
            blinkTimer = 0f;
            Color current = speedBarFill.color;
            speedBarFill.color = current == Color.red ? usualcolor : Color.red;
        }
    }

    /*IEnumerator BlinkSpeedBar()
    {
        isBlinking = true;
        Color normalColor = Color.white;
        Color blinkColor = Color.red;

        while (true)
        {
            speedBarFill.color = blinkColor;
            yield return new WaitForSeconds(blinkwait);
            speedBarFill.color = normalColor;
            yield return new WaitForSeconds(blinkwait);
        }
    }*/
}