using UnityEngine;

public class momentumBTN : MonoBehaviour
{
    public taskButtons taskButtons;
    public RectTransform rectTransform;
    
    public void doTheWork()
    {
        if (GameManager.Instance.taskActive == true && GameManager.spoonsINT != 0)
        {
            GameManager.spoonsINT -= taskButtons.hardSpoonCost;
            GameManager.Instance.spoonNotifications("SpoonDecrease_UI");
            GameManager.momentumINT += 8;
            if (GameManager.spoonsINT == 0 || GameManager.spoonsINT < 0)
            {
                taskButtons.deactivateTaskClicking();
                GameManager.momentumINT = 0;
                Debug.Log("spoons have run out");
            }
            else
            {
                if (GameManager.momentumINT > 100 || GameManager.momentumINT == 100)
                {
                    taskButtons.deactivateTaskClicking();
                    GameManager.momentumINT = 0;
                }
                if (GameManager.day == 4 || GameManager.day == 5 )
                {
                    Vector3 temp = new Vector3();
                    while ((temp.x > -498f && temp.x < 623) && (temp.y > -110f && temp.y < 110))
                    {
                        temp = new Vector3(Random.Range(-718f, 718f), Random.Range(-319f, 319f), 0);
                    }
                    rectTransform.localPosition = temp;

            }
             

            }
               
        }
    }
}
