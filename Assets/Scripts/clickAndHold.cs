using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class clickAndHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public actionButtons currentButton;

    public int spoonCost;

    public float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField] private Slider slider;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //Debug.Log("Pointer Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    private void Update()
    {
        currentButton = GameManager.Instance.currentButton.GetComponent<actionButtons>();
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (slider.value == slider.maxValue)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
            slider.value = pointerDownTimer / requiredHoldTime;
        }
        else
        {
            pointerDownTimer -= Time.deltaTime;
            slider.value = pointerDownTimer / requiredHoldTime;
        }
            
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        GameManager.spoonsINT -= spoonCost;
        GameManager.Instance.spoonNotifications("SpoonDecrease_UI");
        GameObject[] allActionButtons = GameObject.FindGameObjectsWithTag("actionBTN");
        for (int i = 0; i < allActionButtons.Length; i++)
        {
            allActionButtons[i].GetComponent<Button>().interactable = true;
        }
        currentButton.animator.SetInteger("state", currentButton.animatorInteger + 1);
    }
}
