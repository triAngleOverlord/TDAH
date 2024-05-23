using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momentumBTN : MonoBehaviour
{
    public taskButtons taskButtons;
    
    public void doTheWork()
    {
        if (GameManager.Instance.taskActive == true && GameManager.spoonsINT != 0)
        {
            if (GameManager.momentumINT < 33)
                GameManager.spoonsINT -= taskButtons.hardSpoonCost;
            else
                GameManager.spoonsINT -= taskButtons.softSpoonCost;

            GameManager.momentumINT += 2;
        }
    }
}
