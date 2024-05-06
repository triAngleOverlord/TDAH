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
    public static float moodINT;
    public static float peeINT;

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
    public static float timeRate;
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
    }
    void Start()
    {
        InvokeRepeating("changeTheTime", 0.01f, 1f);
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

    public void changeClockSpeed()
    {
        CancelInvoke();
        InvokeRepeating("changeTheTime", 0.01f, timeRate);
    }

    public void changeAnimationUp()
    {
        if (position == 0)
        {
            animator.SetFloat("direction", 1f);
            animator.Play("lookUp_01");
            position = 2;
            lookUpBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if (position == 1)
        {
            animator.Play("lookDown");
            animator.SetFloat("direction", -1f);
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }

    public void changeAnimationDown()
    {
        if (position == 0)
        {
            animator.SetFloat("direction", 1f);
            animator.Play("lookDown");
            position = 1;
            lookDownBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if (position == 2)
        {
            animator.SetFloat("direction", -1f);
            animator.Play("lookUp_01");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }
    public void changeAnimationLeft()
    {
        if (position == 0)
        {
            animator.SetFloat("direction", 1f);
            animator.Play("lookLeft_01");
            position = 4;
            lookUpBTN.SetActive(false);
            lookDownBTN.SetActive(false);
            lookLeftBTN.SetActive(false);
        }
        else if (position == 3)
        { 
            animator.SetFloat("direction", -1f);
            animator.Play("lookRight");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }
    }
    public void changeAnimationRight()
    {
        if (position == 0)
        {
            animator.SetFloat("direction", 1f);
            animator.Play("lookRight");
            position = 3;
            lookUpBTN.SetActive(false);
            lookDownBTN.SetActive(false);
            lookRightBTN.SetActive(false);
        }
        else if(position == 4)
        {
            animator.SetFloat("direction", -1f);
            animator.Play("lookLeft_01");
            position = 0;
            lookDownBTN.SetActive(true);
            lookLeftBTN.SetActive(true);
            lookRightBTN.SetActive(true);
            lookUpBTN.SetActive(true);
        }

    }
}
