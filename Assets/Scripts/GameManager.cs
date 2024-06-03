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
    public static float spoonRateINT;//real time seconds
    public float moodINT;
    public float moodRateINT;
    public MoodStates moodState;
    public static float momentumINT;
    public static float momentumRATE;//real time seconds

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
    public GameObject nyanCat;

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
        hour = 14;

        momentumBar_UI.SetActive(false);
        typingBar_UI.SetActive(false);
        clickAndHold_UI.SetActive(false);
        findingBar_UI.SetActive(false);
        screen.SetActive(false);
        timeRate = 2;
        spoonRateINT = 1f;
        spoonsINT = 100;
        moodINT = 10;
        day = 1;
        momentumRATE = 2f;
    }
    void Start()
    {
        StartCoroutine(changeTheTime());
        StartCoroutine(spoonRate());
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
            else if (momentumINT > 0 || momentumINT == 49)
                momentumINT = 49;
        }

       if (taskActive==true)
        {
            float nyanCatChance = Random.Range(0.0f, 100.0f);
            if (nyanCatChance > 0.1 && nyanCatChance < 0.11)
            {
                Instantiate(Resources.Load<GameObject>("NyanCat"), GameObject.Find("MainPanel").transform);
                Debug.Log(nyanCatChance);
            }

        }
        
            

    }

    public IEnumerator changeTheTime()
    {
        minute++;

        if (minute == 60)
        {
            minute = 0;
            hour++;
            if (hour == 24)
            {
                hour = 0;
                day++;
                dayUI.text = new string(day.ToString());
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
        StartCoroutine(changeTheTime());
    }


    public IEnumerator spoonRate()
    {
        if (spoonsINT < 0)
                spoonsINT = 0;
        if (taskActive == false)
        {
            if (spoonsINT > 0 || spoonsINT ==0)
                spoonsINT++;
        }
            spoon_UI.text = new string(spoonsINT.ToString());
            yield return new WaitForSeconds(spoonRateINT);
        
        
        StartCoroutine (spoonRate());
    }

    public IEnumerator moodRate()
    {
        if(moodINT < 0 || moodINT ==0)
        {
            moodState = MoodStates.Paralysis;
            moodFace.texture = Resources.Load<Texture>("paralysis");
            moodRateINT = 1f;
            spoonRateINT = 1f;//
        }
        else if (moodINT < 3 && moodINT > 0)
        {
            moodState = MoodStates.Upset;
            moodFace.texture = Resources.Load<Texture>("sad");
            moodRateINT = 0.5f;
            spoonRateINT = 1f;//
        }
        else if (moodINT < 6 && moodINT > 3)
        {
            moodState = MoodStates.Neutral;
            moodFace.texture = Resources.Load<Texture>("neutral");
            moodRateINT = 0.2f;
            spoonRateINT = 1f;//
        }
        else if ((moodINT==10 || moodINT < 10) && moodINT >6)
        {
            moodState = MoodStates.Happy;
            moodFace.texture = Resources.Load<Texture>("happy");
            moodRateINT = 0.1f;
            spoonRateINT = 1f;//
        }

        moodINT -= moodRateINT;
        yield return new WaitForSeconds(2);
        StartCoroutine(moodRate());
    }

    public void changeClockSpeed()
    {
        CancelInvoke();
        InvokeRepeating("changeTheTime", 0.01f, timeRate);
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
            clockPanel.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-772.5f, 625, 0);
        }
        else if (position == 0)
        {
            lookingAround(true);
            clockPanel.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-772.5f, 477.23f, 0);
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
}
