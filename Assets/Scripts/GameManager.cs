using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Animator animator;
    public int position;

    [Header("Stats")]
    public static int spoonsINT;
    public static float moodINT;
    public MoodStates moodState;
    public static float momentumINT;
    public static float momentumRATE;//real time seconds
    public static float thoughtChance;
    public static float commentChance;

    [Header("Objective")]
    public static float essayProgress;
    [SerializeField] private Slider essayProgressUI;
    public static float reportsProgress;
    [SerializeField] private Slider reportsProgressUI;
    public static float lectureProgress;
    [SerializeField] private Slider lectureProgressUI;
    public static float posterProgress;
    [SerializeField] private Slider posterProgressUI;

    [Header("Buttons")]
    public GameObject lookUpBTN;
    public GameObject lookDownBTN;
    public GameObject lookLeftBTN;
    public GameObject lookRightBTN;
    public GameObject posterBTN;

    [Header("Clock Stuff")]
    [SerializeField] TextMeshProUGUI hourHand;
    [SerializeField] TextMeshProUGUI minuteHand;
    [SerializeField] TextMeshProUGUI dayUI;
    [SerializeField] private GameObject clockPanel;
    public static float hour;
    public static float minute;
    public static float timeRate;
    public static float day;

    [Header("UI Elements")]
    public GameObject momentumBar_UI;
    public GameObject typingBar_UI;
    public GameObject findingBar_UI;
    public GameObject clickAndHold_UI;
    public TextMeshProUGUI spoon_UI;
    [SerializeField] private RawImage moodFace;
    public GameObject screen;
    //public GameObject nyanCat;
    public GameObject sleepCanvas;

    [Header("References")]
    public GameObject currentButton;
    public bool taskActive;

    public enum MoodStates
    {
        Happy, Neutral, Upset, Paralysis
    }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }

        timeRate = 0.001f;
        position = 0;
        hour = 7;

        momentumBar_UI.SetActive(false);
        typingBar_UI.SetActive(false);
        clickAndHold_UI.SetActive(false);
        findingBar_UI.SetActive(false);
        screen.SetActive(false);
        posterBTN.SetActive(false);
        
        lookingAround(false);
        sleepCanvas.SetActive(false);
        posterProgressUI.gameObject.SetActive(false);
        //addPoster();

        timeRate = 1f;
        spoonsINT = 100;
        moodINT = 10f;
        day = 5;
        momentumRATE = 2f;
        essayProgress = 10;
        lectureProgress = 2;
        reportsProgress = 6;
        posterProgress = 0;

        thoughtChance = 5;
        commentChance = 20;
        

    }
    void Start()
    {
        StartCoroutine(changeTheTime());
        StartCoroutine(moodRate());
    }

    // Update is called once per frame
    void Update()
    {
       if (momentumBar_UI.activeSelf == true)
        {
            if (momentumINT > 0 )
            {
                momentumINT -= Time.deltaTime* momentumRATE;
            }
            else if (momentumINT < 0|| momentumINT == 0)
                momentumINT = 0;
            else if (momentumINT > 0 || momentumINT == 100)
                momentumINT = 100;
        }

       spoon_UI.GetComponent<TextMeshProUGUI>().text = spoonsINT.ToString(); 
       
    }

    public IEnumerator changeTheTime()
    {
        minute++;

        if (minute == 60 || minute > 60)
        {
            minute = 0;
            hour++;
            if (hour == 2)
            {
                hour = 0;
                day--;
                dayUI.text = new string(day.ToString());
                goToBed("It's getting late. Let's sleep and continue tomorrow.");
            }

            if (hour < 10)
            {
                hourHand.text = new string("0" + hour.ToString() + ":");
            }
            else
            {
                hourHand.text = new string(hour.ToString() + ":");

            }
        }

        if (minute < 10)
        {
            minuteHand.text = new string("0" + minute.ToString());
        }
        else
        {
            minuteHand.text = new string(minute.ToString());
        }

        yield return new WaitForSeconds(timeRate);
        if (taskActive == true && day != 1)
        {
            Debug.Log(day);
            int chance = 0;
            if (day == 2)
                chance = 2;
            else if (day == 3)
                chance = 5;
            else if (day == 4)
                chance = 7;
            else if (day == 5)
                chance = 10;
            int nyanCatChance = Random.Range(0, 100);
            if (nyanCatChance > 1 && nyanCatChance < chance)
            {
                Instantiate(Resources.Load<GameObject>("NyanCat"), GameObject.Find("MainPanel").transform);
                Debug.Log(nyanCatChance);
            }
        }
        StartCoroutine(changeTheTime());
    }

    public IEnumerator moodRate()
    {
        if(moodINT < 1.5f || moodINT == 1.5f )
        {
            moodState = MoodStates.Paralysis;
            moodFace.texture = Resources.Load<Texture>("paralysis");
            spoonsINT -= 1;
        }
        else if ((moodINT < 3 || moodINT ==3) && moodINT > 1.5f)
        {
            moodState = MoodStates.Upset;
            moodFace.texture = Resources.Load<Texture>("sad");
            spoonsINT += 1;
        }
        else if (moodINT < 6 && moodINT > 3)
        {
            moodState = MoodStates.Neutral;
            moodFace.texture = Resources.Load<Texture>("neutral");
            spoonsINT += 2;
        }
        else if (moodINT >6 || moodINT == 6)
        {
            moodState = MoodStates.Happy;
            moodFace.texture = Resources.Load<Texture>("happy");
            spoonsINT += 3;
        }

        moodINT -= 0.1f;

        if (moodINT < 0)
            moodINT = 0;
        else if (moodINT > 10)
            moodINT = 10;

        if (spoonsINT < 0)
        {
            spoonsINT = 0;
            goToBed("I don't feel... anything...let's just... do nothing... for the rest of the day... and... go to bed...");
        }
            
        yield return new WaitForSeconds(1);
        StartCoroutine(moodRate());
    }


    public void changeAnimationUp()
    {
        if (position == 0 && taskActive == false)
        {
            animator.Play("lookUp_01");
            position = 2;
            lookUpBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if (position == 1 && taskActive == false)
        {
            animator.Play("lookDownBack");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }

    public void changeAnimationDown()
    {
        if (position == 0 && taskActive == false)
        {
            animator.Play("lookDown");
            position = 1;
            lookDownBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if (position == 2 && taskActive == false)
        {
            animator.Play("lookUpBack");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }
    public void changeAnimationLeft()
    {
        if (position == 0 && taskActive == false)
        {
            animator.Play("lookLeft_01");
            position = 4;
            lookUpBTN.SetActive(false);
            lookDownBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
        }
        else if (position == 3 && taskActive == false)
        { 
            animator.Play("lookRightBack");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }
    public void changeAnimationRight()
    {
        if (position == 0 && taskActive == false)
        {
            animator.Play("lookRight");
            position = 3;
            lookUpBTN.SetActive(false);
            lookDownBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if(position == 4 && taskActive == false)
        {
            animator.Play("lookLeftBack");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }

    }

    public void outOfRoom()
    {
        if (position == 6 || position == 4)
        {
            lookingAround(false);
        }
        else if (position == 0)
        {
            lookingAround(true);
        }
    }

    public void lookingAround(bool state)
    {
        lookUpBTN.SetActive(state);
        lookDownBTN.SetActive(state);
        lookLeftBTN.SetActive(state);
        lookRightBTN.SetActive(state);
    }

    public void spoonNotifications(string notif)
    {
        var clone = Instantiate(Resources.Load<GameObject>(notif), GameObject.Find("StatsPanel").transform);
        StartCoroutine(gainSpoonNotif(clone));
    }
    public IEnumerator gainSpoonNotif(GameObject clone)
    {
        yield return new WaitForSeconds(2);
        Destroy(clone);
    }

    public void goToBed(string narrate)
    {
        StopAllCoroutines();
        GameObject[] animators = GameObject.FindGameObjectsWithTag("anim");
        foreach (var animator in animators)
        {
            animator.GetComponent<Animator>().SetBool("default", true);
        }
        clickAndHold_UI.SetActive(false);
        sleepCanvas.SetActive(true);
        sleepCanvas.GetComponentInChildren<Animator>().Play("dimToBlack");
        sleepCanvas.GetComponentInChildren<TextMeshProUGUI>().text = new string(narrate);
        //lookingAround(false);
        StartCoroutine(sleeping());
    }

    public IEnumerator sleeping()
    {
        if (day == 4)
            addPoster();
        else if (day ==0)
            //endScreen
        thoughtChance += 2;
        dayUI.text = new string(day.ToString());
        lookingAround(false);
        yield return new WaitForSecondsRealtime(10);
        var sleepHours = 0;
        if (hour < 3)
        {
            moodINT = 4 - hour;
            sleepHours = 7 - (int)hour;
        }
        else if (hour >20)
        {
            moodINT = 6 + (24 - (int)hour) ;
            sleepHours = 7 + (24 - (int)hour);
        }
        else
        {
            moodINT = 5;
            sleepHours = 5;
        }
            
        spoonsINT = sleepHours * 10;
        
        GetComponent<Animator>().Play("inBed");
        sleepCanvas.SetActive(false);
        
        hour = 7;
        minute = 0;
        StartCoroutine(changeTheTime());
        StartCoroutine(moodRate());
        
    }

    public void addPoster()
    {
        posterBTN.SetActive(true);
        ThoughtsManager.instantiateThought("Mom said it looked like I wasn't working. Now I have a poster to do...", "LookUp_BTN");
        ThoughtsManager.instantiateThought("If I don't work on it, she'll bug me about it.", "Poster_BTN");
        posterProgressUI.gameObject.SetActive(true);
        
        StartCoroutine(commentLikelyHood());
    }

    public IEnumerator commentLikelyHood()
    {
        int num = Random.Range(0, 100);
        if (num > 0 && num < commentChance)
            Instantiate(Resources.Load("parentComment"), GameObject.Find("CommentsPanel").transform);
        yield return new WaitForSecondsRealtime(10);
        if (posterProgress != 100)
            StartCoroutine(commentLikelyHood());
    }
}
