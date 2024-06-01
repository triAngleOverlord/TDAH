using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButtons : MonoBehaviour
{
    public int spoonCost;
    public int spoonRate;
    public actionType type;

    public enum actionType
    {
        click, clickHold, scrub
    }

    public void doAction()
    {
        switch(type)
        {
            case actionType.click:
                break;  
            case actionType.clickHold:  GameManager.Instance.clickAndHold_UI.SetActive(true);
                                        GameObject.Find("ClickHold_BTN").GetComponent<clickAndHold>().spoonCost = spoonCost;
                break;
            case actionType.scrub:
                break;
        }

    }

}
