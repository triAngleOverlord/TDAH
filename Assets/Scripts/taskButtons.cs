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
        animator.SetInteger("state", 1);
        momentumBar.SetActive(true);
        GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().taskButtons = this;
        GameObject.Find("StopTask_BTN").GetComponent<taskButtons>().animator = animator;
        

    }

    public void deactivateTask()
    {
        GameManager.Instance.taskActive = false;
        animator.SetInteger("state", 2);
        
    }

    public void takeSpoonsAway()
    {
        GameManager.spoonsINT -= softSpoonCost;
    }

}
