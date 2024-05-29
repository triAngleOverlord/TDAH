using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private GameObject lookUpBTN;
    [SerializeField] private GameObject lookDownBTN;
    [SerializeField] private GameObject lookLeftBTN;
    [SerializeField] private GameObject lookRightBTN;

    [Header("Clock")]
    public static float hour;
    public static float minute;
    [SerializeField] TextMeshProUGUI hourHand;
    [SerializeField] TextMeshProUGUI minuteHand;
    [SerializeField] TextMeshProUGUI dayUI;
    public static float timeRate;
    public static float day;

    [Header("UI Elements")]
    public GameObject momentumBar_UI;
    public TextMeshProUGUI spoon_UI;

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
        spoonRateINT = 1f;
        spoonsINT = 100;
        moodINT = 10;
        day = 1;
        momentumRATE = 0.5f;
    }
    void Start()
    {
        InvokeRepeating("changeTheTime", 0.01f, 0.01f);
        StartCoroutine(momentumBar());
        StartCoroutine(spoonRate());
        StartCoroutine(moodRate());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void changeTheTime()
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

    }

    public IEnumerator momentumBar()
    {
        if (momentumINT > 0 || momentumINT ==0)
            momentumINT--;
        else if (momentumINT < 0)
            momentumINT = 0;
        else if (momentumINT > 0)
            momentumINT = 50;
        yield return new WaitForSecondsRealtime(momentumRATE);
        
        StartCoroutine(momentumBar());
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
            moodRateINT = 1f;
            spoonRateINT = 1f;//
        }
        else if (moodINT < 3 && moodINT > 0)
        {
            moodState = MoodStates.Upset;
            moodRateINT = 0.5f;
            spoonRateINT = 1f;//
        }
        else if (moodINT < 6 && moodINT > 3)
        {
            moodState = MoodStates.Neutral;
            moodRateINT = 0.2f;
            spoonRateINT = 1f;//
        }
        else if ((moodINT==10 || moodINT < 10) && moodINT >6)
        {
            moodState = MoodStates.Happy;
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
        if (position == 6)
        {
            lookingAround(false);
            hourHand.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-803, 625, 0);
            minuteHand.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-685, 625, 0);
        }
        else if (position == 0)
        {
            lookingAround(true);
            hourHand.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-803, 500, 0);
            minuteHand.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-685, 500, 0);
        }
    }

    public void lookingAround(bool state)
    {
        lookUpBTN.SetActive(state);
        lookDownBTN.SetActive(state);
        lookLeftBTN.SetActive(state);
        lookRightBTN.SetActive(state);
    }
}
