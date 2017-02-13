using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using System;

public class ButtonClickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public float decreaseHeatAmount = .2f;
    public float cooldownTime = 1f;
    public Animator animator;

    float elapsedTime = 0f;
    bool pressed = false;

    void Start()
    {
    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        elapsedTime = cooldownTime;
    }

    public void Update()
    {
        elapsedTime -= Time.deltaTime;
        elapsedTime = Math.Max(0, elapsedTime);
        if (pressed)
        {
            HeatCtrlScript.DecraseSlider(decreaseHeatAmount * Time.deltaTime);
        }
    }

    public bool GetPressed()
    {
        return pressed;
    }

    public void SetPressed(bool pressed)
    {/*
        if(elapsedTime > 0)
        {
            return;
        }
        if (pressed == false)
        {
            elapsedTime = cooldownTime;
        }*/
        if (this.pressed != pressed)
        {
            animator.SetBool("Extended", pressed);
        }
        this.pressed = pressed;
        
    }

    
}
