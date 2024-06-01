using UnityEngine;

public class taskButtons : MonoBehaviour
{
    public GameObject momentumBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    public int divider;
    [SerializeField] private Animator animator;

    private float downTimer;
    void Start()
    {
        momentumBar = GameManager.Instance.momentumBar_UI;
    }

    // Update is called once per frame
    void Update()
    {
        downTimer -= Time.deltaTime;

    }

    public void activateTask()
    {
        GameManager.Instance.taskActive = true;
        animator.SetInteger("state", 1);
        momentumBar.SetActive(true);
        GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().taskButtons = this;
        GameObject.Find("StopTask_BTN").GetComponent<taskButtons>().animator = animator;
        momentumBar.GetComponent<momentumBar>().divisionValue = divider;
        

    }

    public void deactivateTask()
    {
        GameManager.Instance.taskActive = false;
        animator.SetInteger("state", 2);
        
    }

    public void takeSpoonsAway()
    {
        int x = (int) downTimer ;
        GameManager.spoonsINT = softSpoonCost * x/ 1;
    }

}
