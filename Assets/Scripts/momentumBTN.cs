using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momentumBTN : MonoBehaviour
{
    public taskButtons taskButtons;
    public RectTransform rectTransform;
    public int divider;
    
    public void doTheWork()
    {
        if (GameManager.Instance.taskActive == true && GameManager.spoonsINT != 0)
        {
            if (GameManager.momentumINT < 33)
                GameManager.spoonsINT -= taskButtons.hardSpoonCost;
            else
                GameManager.spoonsINT -= taskButtons.softSpoonCost;

            GameManager.momentumINT += 10;
            Vector3 temp = new Vector3();
            while ((temp.x > -498f && temp.x < 623) && (temp.y > -110f && temp.y < 110))
            {
                temp = new Vector3(Random.Range(-718f, 718f), Random.Range(-319f, 319f), 0);
            }
            rectTransform.localPosition = temp;
        }
    }
}
