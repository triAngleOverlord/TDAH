using UnityEngine;

public class taskButtons : MonoBehaviour
{
    public GameObject momentumBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    public int divider;
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
        momentumBar.GetComponent<momentumBar>().divisionValue = divider;
        GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().divider = divider;
        

    }

    public void deactivateTask()
    {
        GameManager.Instance.taskActive = false;
        animator.SetInteger("state", 2);
        
    }


}
