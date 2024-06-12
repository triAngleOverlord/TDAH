using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class actionButtons : MonoBehaviour
{
    public int spoonCost;
    public int timeCost;
    public int moodCost;

    public actionType type;
    public string beginAnimation;

    public Animator animator = null;
    public int animatorInteger;

    public enum actionType
    {
         clickHold
    }

    public void doAction()
    {
        if (GameManager.spoonsINT > spoonCost)
        {
            GameObject[] allActionButtons = GameObject.FindGameObjectsWithTag("actionBTN");
            for (int i = 0; i < allActionButtons.Length; i++)
            {
                allActionButtons[i].GetComponent<Button>().interactable = false;
            }
            beginCamAnim();
            GameManager.Instance.currentButton = gameObject;

        }
        
        

    }

    public void beginCamAnim()
    {
        GameObject.Find("Main Camera").GetComponent<Animator>().Play(beginAnimation);
        animator.SetBool("default", false);
        animator.SetInteger("state", animatorInteger);
    }


    public void whichUI()
    {
        switch (type)
        {
            case actionType.clickHold:
                
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().spoonCost = spoonCost;
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().moodCost = moodCost;
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().timeCost = timeCost;
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().pointerDownTimer = 0.5f;
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().currentButton = this;
                break;
        }
    }

    public void snooze()
    {
        GameManager.spoonsINT += spoonCost;
        GameManager.minute += timeCost;
        GameManager.moodINT += moodCost;
        GameManager.Instance.sleepCanvas.SetActive(true);
        GameManager.Instance.sleepCanvas.GetComponentInChildren<Animator>().Play("dimToBlack");
        GameManager.Instance.sleepCanvas.GetComponentInChildren<TextMeshProUGUI>().text = new string("I'll get up in a few minutes");
        StartCoroutine(napTime());
    }

    public IEnumerator napTime()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Main Camera").GetComponent<Animator>().Play("inBed");
        GameManager.Instance.sleepCanvas.SetActive(false);
    }

    public void outOfBed()
    {
        GameManager.spoonsINT -= spoonCost;
        GameManager.moodINT -= moodCost;
    }
    

}
