using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeHoldDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GearSystem gearSystem;

    public void Init(GearSystem gs)
    {
        gearSystem = gs;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        gearSystem.StopBreak();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        gearSystem.StartBreak();
    }

    

}
   

