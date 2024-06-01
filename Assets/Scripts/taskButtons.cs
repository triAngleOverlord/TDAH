using UnityEngine;

public class taskButtons : MonoBehaviour
{
    public GameObject momentumBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    public int divider;
    [SerializeField] private Animator animator;
    public taskType type;
    private int animatorINT;
    public string password = "";

    public enum taskType
    {
        clicking, finding, typing
    }

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
        switch(type)
        {
            case taskType.clicking:
                momentumBar.SetActive(true);
                GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().taskButtons = this;
                GameObject.Find("StopTask_BTN").GetComponent<taskButtons>().animator = animator;
                momentumBar.GetComponent<momentumBar>().divisionValue = divider;
                GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().divider = divider;
                break;

            case taskType.finding: 
                break;

            case taskType.typing:
                password = (generateRandomLetters());
                break;
        }

        
        animator.SetInteger("state", animatorINT);

        
        

    }

    public void deactivateTask()
    {
        GameManager.Instance.taskActive = false;
        animator.SetInteger("state", 2);
        
    }

    public static string generateRandomLetters()
    {
        var allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var length = 12;

        var randomChars = new char[length];

        for (var i = 0; i < length; i++)
        {
            randomChars[i] = allChars[UnityEngine.Random.Range(0, allChars.Length)];
        }

        return new string(randomChars);
    }

    public void submitTyping()
    {

    }


}
