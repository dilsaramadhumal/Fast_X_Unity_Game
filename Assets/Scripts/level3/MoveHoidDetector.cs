using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveHoidDetector : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private CarSideMovement carsidemovement;

    public void Init(CarSideMovement cs)
    {
        carsidemovement = cs;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        carsidemovement.stopMove();
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        carsidemovement.moveSide();
    }
}
