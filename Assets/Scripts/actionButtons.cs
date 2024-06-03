using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionButtons : MonoBehaviour
{
    public int spoonCost;
    public int spoonRate;
    public int timeCost;
    public actionType type;

    [SerializeField] private Animator animator = null;
    public int animatorInteger;

    public enum actionType
    {
        click, clickHold, scrub, goToBed
    }

    public void doAction()
    {
        GameObject[] allActionButtons = GameObject.FindGameObjectsWithTag("actionBTN");
        for (int i = 0; i < allActionButtons.Length; i++)
        {
            allActionButtons[i].GetComponent<Button>().interactable = false;
        }
        switch(type)
        {
            case actionType.click:      animator.SetInteger("state", animatorInteger);
                break;  
            case actionType.clickHold:  GameManager.Instance.clickAndHold_UI.SetActive(true);
                                        GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().spoonCost = spoonCost;
                break;
            case actionType.scrub:
                break;
        }

    }

}
