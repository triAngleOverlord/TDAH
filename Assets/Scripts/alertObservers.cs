using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertObservers : MonoBehaviour
{
    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("BathroomEnded"))
        {
            //Debug.Log("gone back");
            GameObject.Find("Main Camera").GetComponent<Animator>().Play("justToSink");
            // Do other things based on an attack ending.
        }
        else if (message.Equals("ClickAndHold"))
        {
            //Debug.Log("event registered");
            GameManager.Instance.clickAndHold_UI.SetActive(true);
            //GameObject.Find("Click&Hold").GetComponent<clickAndHold>().currentButton = GameManager.Instance.currentButton.GetComponent<actionButtons>();
            GameManager.Instance.currentButton.GetComponent<actionButtons>().whichUI();
        }
        else if (message.Equals("finishPetDawg"))
        {
            GameObject.Find("Main Camera").GetComponent<Animator>().Play("backPetDawg");
        }
    }
}
