  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSideMovement : MonoBehaviour
{

    public float sideMoveSpeed = 5f;
    public float carXPos;
    //public float highSpeedPenalty = 0.3f;
    //public float lowSpeedThreshold = 0.4f;

    public Button leftLockButton;
    public Button rightLockButton;
    public Button leftMoveButton;
    public Button rightMoveButton;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public bool goLeft = false;
    public bool goright = false;

    //private GearSystem gearSystem;

    void Start()
    {
        //gearSystem = FindObjectOfType<GearSystem>();
        leftMoveButton.gameObject.AddComponent<MoveHoidDetector>().Init(this);
        rightMoveButton.gameObject.AddComponent<MoveHoidDetector>().Init(this);

        leftLockButton.onClick.AddListener(() => SetLockState(true));
        rightLockButton.onClick.AddListener(() => SetLockState(false));

        leftMoveButton.interactable = false;
        rightMoveButton.interactable = false;

        LockBoth();

    }

    void SetLockState(bool leftUnlocking)
    {
        if (leftUnlocking)
        {
            canMoveLeft = true;
            canMoveRight = false;
            leftLockButton.image.sprite = unlockedSprite;
            rightLockButton.image.sprite = lockedSprite;

            leftMoveButton.interactable = true;
            rightMoveButton.interactable = false;

        }
        else
        {
            canMoveRight = true;
            canMoveLeft = false;
            rightLockButton.image.sprite = unlockedSprite;
            leftLockButton.image.sprite = lockedSprite;

            rightMoveButton.interactable = true;
            leftMoveButton.interactable = false;
        }
    }

    void LockBoth()
    {
        canMoveLeft = false;
        canMoveRight = false;
        leftLockButton.image.sprite = lockedSprite;
        rightLockButton.image.sprite = lockedSprite;
    }

    public void moveSide()
    {
        goLeft = true;
        goright = true; 
    }

    public void stopMove()
    {
        goLeft = false;
        goright = false;
    }

    /*private void Update()
    {
       if(canMoveLeft && goLeft)
        {
            
            carXPos += -sideMoveSpeed * Time.deltaTime;
        }

       if (canMoveRight && goright)
        {
            carXPos += sideMoveSpeed * Time.deltaTime;
        }
    }*/

    


}
