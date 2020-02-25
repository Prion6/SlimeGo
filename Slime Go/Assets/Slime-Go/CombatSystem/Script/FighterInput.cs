using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FighterInput : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Fighter avatar;

    public float dodgeThreshold = 3;
    public float specialAttackPressedActive = 0.8f;

    private bool isPressed;

    private float goalTime;

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.delta.x > dodgeThreshold){
            avatar.DodgeRight();
        }
        else if(eventData.delta.x < -dodgeThreshold)
        {
            avatar.DodgeLeft();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        avatar.Attack();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        goalTime = Time.time + specialAttackPressedActive;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed)
        {
            if (Time.time >= goalTime)
            {
                avatar.SuperAttack();
            }
        }
    }
}
