using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToSleep : MonoBehaviour
{
    private Animator animator;
    private int sleepHours = 0;
    public void stopEverything()
    {
        GameManager.Instance.StopAllCoroutines();
        GameManager.Instance.outOfRoom();

        animator = GameObject.Find("Main Camera").GetComponent<Animator>();
        animator.Play(gameObject.name);
        sleepHours = 0;
        if (GameManager.hour <7)
            sleepHours = 7- (int)GameManager.hour;
        else 
            sleepHours = 7 + (24 - (int)GameManager.hour);

        results.sleepCounter += sleepHours;
        StartCoroutine(wakingUp(sleepHours));
    }

    public IEnumerator wakingUp(int hoursSlept)
    {
        yield return new WaitForSecondsRealtime(5);
        GameManager.hour = 7;
        GameManager.minute = 0;
        GameManager.spoonsINT = hoursSlept * 10;///BALANCE
        StartCoroutine(GameManager.Instance.changeTheTime());
    }
}
