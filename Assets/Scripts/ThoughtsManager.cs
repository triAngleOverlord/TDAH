using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static thoughtActions;

public class ThoughtsManager : MonoBehaviour
{
    public static ThoughtsManager instanceTH;

    public GameObject thoughtBubble;

    
    void Awake()
    {
        instantiateThought("5 days till the exam. How much do I have left to do?", "LookUp_BTN");
        StartCoroutine(thoughtChance());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void instantiateThought(string text, string objectName)
    {
        //Debug.Log(objectName);
        var clone = GameObject.Find(objectName).AddComponent<thoughtActions>();
        var firstThought = Instantiate(Resources.Load<GameObject>("thoughtBubble"));
        firstThought.GetComponentInChildren<TextMeshProUGUI>().text = new string(text);
        clone.GetComponent<thoughtActions>().whichThought = firstThought;
        clone.GetComponent<Button>().onClick.AddListener(() => clone.GetComponent<thoughtActions>().doesAction());

    }  

    public void randomThought()
    {
        int num = Random.Range(0,10);

        if (num == 0)
            instantiateThought("My dog must be feeling lonely right now (-mood)", "petDawg");
        else if (num == 1)
            instantiateThought("When is the last time I had some water? (-mood)", "drinkWater");
        else if (num == 2)
            instantiateThought("Feeling a void in my stomach (-mood)", "eatFood");
        else if (num == 3)
            instantiateThought("Maybe I need a snack to get back into the swing of things (-mood)", "snack");
        else if (num == 4)
            instantiateThought("My face feels so oily (-mood)", "washFace");
        else if (num == 5)
            instantiateThought("There's a chunk of leftovers between my teeth (-mood)", "brushTeeth");
        else if (num == 6)
            instantiateThought("My face feels so dry (-mood)", "moisturise");
        else if (num == 7)
            instantiateThought("Eww I smell really bad (-mood)", "shower");
        else if (num == 8)
            instantiateThought("I really need to goooo! (-mood)", "toilet");
        else if (num == 9)
            instantiateThought("Feeling really drained right now (-mood)", "goToSleep");
        else if (num == 10)
            instantiateThought("I wonder if my pupper is doing alright? (-mood)", "petDawg");
        

    }

    public IEnumerator thoughtChance()
    {
        int chance = Random.Range(0, 100);
        //Debug.Log(chance);
        if (chance < GameManager.thoughtChance && chance > 0.0f)
            randomThought();
        yield return new WaitForSecondsRealtime(2);
        StartCoroutine(thoughtChance());
    }

}
