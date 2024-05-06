using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskButtons : MonoBehaviour
{
    public GameObject momentumBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    void Start()
    {
        momentumBar = GameManager.Instance.momentumBar_UI;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.taskActive == true && GameManager.spoonsINT !=0)
        {
            if(Input.GetKeyDown("space"))
            {
                if (GameManager.momentumINT < 33)
                    GameManager.spoonsINT -= hardSpoonCost;
                else
                    GameManager.spoonsINT -= softSpoonCost;

                GameManager.momentumINT+=2;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
                GameManager.Instance.taskActive = false;
        }
    }

    public void activateTask()
    {
            GameManager.Instance.taskActive = true;
            momentumBar.SetActive(true);
      
    }
}
