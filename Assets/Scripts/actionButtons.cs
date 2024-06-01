using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButtons : MonoBehaviour
{
    public int spoonCost;
    public int spoonRate;
    public actionType type;

    [SerializeField] private Animator animator = null;
    public int animatorInteger;

    public enum actionType
    {
        click, clickHold, scrub, goToBed
    }

    public void doAction()
    {
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
