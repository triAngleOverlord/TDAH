using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionButtons : MonoBehaviour
{
    public int spoonCost;
    public int timeCost;
    public actionType type;
    public string beginAnimation;

    public Animator animator = null;
    public int animatorInteger;

    public enum actionType
    {
         clickHold, scrub, goToBed
    }

    public void doAction()
    {
        GameObject[] allActionButtons = GameObject.FindGameObjectsWithTag("actionBTN");
        for (int i = 0; i < allActionButtons.Length; i++)
        {
            allActionButtons[i].GetComponent<Button>().interactable = false;
        }
        beginCamAnim();
        GameManager.Instance.currentButton = gameObject;
        

    }

    public void beginCamAnim()
    {
        GameObject.Find("Main Camera").GetComponent<Animator>().Play(beginAnimation);
        animator.SetInteger("state", animatorInteger);
    }


    public void whichUI()
    {
        switch (type)
        {
            case actionType.clickHold:
                
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().spoonCost = spoonCost;
                GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().currentButton = this;
                break;

            case actionType.scrub:
                break;
        }
    }


    

}
