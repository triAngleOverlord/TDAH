using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class momentumBar : MonoBehaviour
{
    public Slider slider;
    public float divisionValue;
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.momentumINT;
    }
}
