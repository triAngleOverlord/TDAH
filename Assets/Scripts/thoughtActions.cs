using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class thoughtActions : MonoBehaviour
{
    public actionsToDo doThis;
    public GameObject whichThought;
    public enum actionsToDo
    {
        noSnooze, lookAtToDoList, bathroomUnlocked, peeFirst, washHands, allHygiene, 
        hallwayAndKitchen, outside, allActionsLocked, lectureUnlocked, essayUnlocked, snackTime, allUnlocked, taskParalysis, bathroomANDkitchen, goToBed
    }
    void Start()
    {

    }

    public void doesAction()
    {
        switch (doThis)
        {
            case actionsToDo.noSnooze: GameObject.Find("snooze").GetComponent<RectTransform>().localPosition = new Vector3(0, -164.28f, 0);
                break;
            case actionsToDo.lookAtToDoList: 
                break;
            case actionsToDo.bathroomUnlocked: 
                break;
            case actionsToDo.peeFirst: 
                break;
            case actionsToDo.washHands: 
                break;
            case actionsToDo.allHygiene: 
                break;
            case actionsToDo.hallwayAndKitchen: 
                break;
            case actionsToDo.outside: 
                break;
            case actionsToDo.allActionsLocked: 
                break;
            case actionsToDo.lectureUnlocked: 
                break;
            case actionsToDo.essayUnlocked: 
                break;
            case actionsToDo.snackTime: 
                break;
            case actionsToDo.allUnlocked: 
                break;
            case actionsToDo.taskParalysis: 
                break;
            case actionsToDo.bathroomANDkitchen: 
                break;
            case actionsToDo.goToBed: 
                break;

        }

        Destroy(whichThought);


    }

    


}
