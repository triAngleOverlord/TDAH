using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class momentumBar : MonoBehaviour
{
    public Slider slider;
    public float value;
    public TextMeshProUGUI percentage;
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (name == "momentumBar")
            value = GameManager.momentumINT;
        else if (name == "EssayProgress")
            value = GameManager.essayProgress;
        else if (name == "ReportProgress")
            value = GameManager.reportsProgress;
        else if (name == "LectureProgress")
            value = GameManager.lectureProgress;
        else if (name == "PosterProgress")
            value = GameManager.posterProgress;

        if (value >100)
            value = 100;
        slider.value = value;
        percentage.text = new string (value.ToString() + "%");
    }
}
