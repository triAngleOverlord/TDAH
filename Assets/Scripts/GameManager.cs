using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Stats")]
    public static int spoonsINT;
    public static float moodINT;
    public static float peeINT;

    [Header("Clock")]
    public static float hour;
    public static float minute;
    public static int dayCount;
    public static string dayName;
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

        timeRate = 0.01f;
    }
    void Start()
    {
        InvokeRepeating("changeTheTime", 0.01f, 0.01f);
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
                dayCount += 1;
                if (dayCount == 7)
                {
                    dayCount = 0;
                }
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
}
