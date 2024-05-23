using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskButtons : MonoBehaviour
{
    public GameObject momentumBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    [SerializeField] private Animator animator;
    void Start()
    {
        momentumBar = GameManager.Instance.momentumBar_UI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateTask()
    {
            GameManager.Instance.taskActive = true;
            momentumBar.SetActive(true);
            animator.Play("writing_01");
        GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().taskButtons = this;

    }

    public void deactivateTask()
    {
        GameManager.Instance.taskActive = false;
        momentumBar.SetActive(false);
        animator.Play("downDefault");
    }

    public void takeSpoonsAway()
    {
        GameManager.spoonsINT -= softSpoonCost;
    }
}
