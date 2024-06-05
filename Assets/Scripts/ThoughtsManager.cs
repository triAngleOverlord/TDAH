using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static thoughtActions;

public class ThoughtsManager : MonoBehaviour
{
    public static ThoughtsManager instanceTH;

    public GameObject thoughtBubble;

    public static int thoughtStage =0;

    public static string[] tutorialTexts = new string [] 
    {
        "Alright, new day, new me!",
        "Let's get up on time! Dismiss 7 am!",
        "I've got a lot to do. Let me first check my to do list above.",
        "5 days till exams. Manageable!",
        "To get the day going, let's do hygenic normal person things!",
        "Toilet", "Wash hands", "Brush teeth", "Wash face", "Moisturise",
        "I am feeling GOOD!", "Let's get started on work!",
        "Oh I'm feeling hungry.", "Breakfast first! Can't work on an empty stomach.","I need some water",
        "Oh, I can't forget to say good morning to my pupper outside!",
        "Alright. What time is it? Lets go check my computer.",
        "Ok it's time to get started actually.", "Boring lecture first...", "Nope, can't get distracted. Go away nyan cat!",
        "Ok, next the essay", "I'm starting to feel a bit tired. I think that's enough writing for now",
        "Let's check how much progress I've made", "Pretty good progress. I think I deserve a snack!",
        "Let's continue working!",
        "I feel really strange...",
        "It's late now... let's go shower and have dinner... maybe I'll feel better afterwards",
        "Perhaps its time to go to bed"
    };
    void Start()
    {
        instantiateThought(tutorialTexts[thoughtStage], "getOutOfBed", thoughtActions.actionsToDo.noSnooze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void instantiateThought(string text, string objectName, actionsToDo act)
    {
        var clone = GameObject.Find(objectName).AddComponent<thoughtActions>();
        clone.GetComponent<thoughtActions>().doThis = act;
        var firstThought = Instantiate(Resources.Load<GameObject>("thoughtBubble"));
        firstThought.GetComponentInChildren<TextMeshProUGUI>().text = new string(text);
        clone.GetComponent<thoughtActions>().whichThought = firstThought;
        clone.GetComponent<Button>().onClick.AddListener(() => clone.GetComponent<thoughtActions>().doesAction());

    }  

}
