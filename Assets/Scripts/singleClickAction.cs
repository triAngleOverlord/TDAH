using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleClickAction : MonoBehaviour
{
    public int spoonCost;
    public int timeCost;
    public int moodCost;

    [SerializeField] private Animator animator = null;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bathroomAction()
    {
        if (GameManager.spoonsINT > spoonCost)
        {
            animator.SetBool("default", false);
            GameObject.Find("Main Camera").GetComponent<Animator>().Play("toSinkAnimation");
            animator.Play(name);
            GameManager.spoonsINT -= spoonCost;
            GameManager.minute += timeCost;
            GameManager.moodINT += moodCost;
        }
    }

    public void patioAction()
    {
        if (GameManager.spoonsINT > spoonCost)
        {
            animator.SetBool("default", false);
            GameObject.Find("Main Camera").GetComponent<Animator>().Play("toPetDawg");
            animator.Play(name);
            GameManager.spoonsINT -= spoonCost;
            GameManager.minute += timeCost;
            GameManager.moodINT += moodCost;
        }
    }

    public void kitchenAction()
    {
        if (GameManager.spoonsINT > spoonCost)
        {
            animator.SetBool("default", false);
            GameObject.Find("Main Camera").GetComponent<Animator>().Play("toKitchenAnimator");
            animator.Play(name);
            GameManager.spoonsINT -= spoonCost;
            GameManager.minute += timeCost;
            GameManager.moodINT += moodCost;
        }
    }
}
