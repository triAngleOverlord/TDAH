using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using System.Threading;

public class clickAndHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public float pointerDownTimer;

    public actionButtons currentButton;

    public int spoonCost;
    public int timeCost;
    public int moodCost;

    public float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField] private Slider slider;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        StartCoroutine(addTime());
        //Debug.Log("Pointer Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        StopAllCoroutines();
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

    public void Reset()
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
        GameManager.spoonsINT -= spoonCost;
        GameManager.moodINT += moodCost;
    }

    public IEnumerator addTime()
    {
        GameManager.minute += timeCost;
        yield return new WaitForSeconds(2);
        StartCoroutine(addTime());
    }
}
