using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class taskButtons : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int animatorINT;
    public taskType type;
    private GameObject momentumBar;
    private GameObject typingBar;
    public int hardSpoonCost;
    public int softSpoonCost;
    [Header("Momentum Bar Only")]
    public int divider;
    [Header("Typing Bar Only")]
    public string password = "";
    [Header("Finding Bar Only")]
    public GameObject screen;
    public VideoPlayer lastestPlayer;

    public enum taskType
    {
        clicking, finding, typing
    }

    void Start()
    {
        momentumBar = GameManager.Instance.momentumBar_UI;
        typingBar = GameManager.Instance.typingBar_UI;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activateTask()
    {
        inactive(false);
        GameManager.Instance.taskActive = true;
        GetComponent<Button>().interactable = false;
        GetComponent<Image>().raycastTarget = false;
        switch (type)
        {
            case taskType.clicking:
                momentumBar.SetActive(true);
                GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().taskButtons = this;
                //GameObject.Find("StopTask_BTN").GetComponent<taskButtons>().animator = animator;
                momentumBar.GetComponent<momentumBar>().divisionValue = divider;
                GameObject.Find("MomentumIncreaseBTN").GetComponent<momentumBTN>().divider = divider;
                break;

            case taskType.finding:
                GameManager.Instance.findingBar_UI.SetActive(true);
                GameObject[] array = GameObject.FindGameObjectsWithTag("find");
                if (GameManager.day == 1 || GameManager.day == 2|| GameManager.day == 3)
                {
                    //only activate the lecture button
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].gameObject.name != "actuallyLecture")
                        {
                            array[i].gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    array[0].SetActive(false);
                    for (int i = 1; i < array.Length; i++)
                    {
                        array[i].GetComponentInChildren<TextMeshProUGUI>().text = generatePhrase();
                        array[i].GetComponent<findVideo>().hasVideo = false;
                        array[i].GetComponent<Image>().color = Color.white;
                    }
                    var lecture = UnityEngine.Random.Range(0, array.Length);
                    array[lecture].GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Videos/whistle");
                    array[lecture].GetComponent<findVideo>().hasVideo = true;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].GetComponent<findVideo>().hasVideo == false)
                        {
                            array[i].GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>(pickAVideo());
                            array[i].GetComponent<findVideo>().hasVideo = true;
                        }
                    } 
                }
                break;

            case taskType.typing:
                typingBar.SetActive(true);
                int length = 0;
                if (GameManager.day == 1 || GameManager.day == 2 || GameManager.day == 3)
                    length = 7;
                else if (GameManager.day == 4)
                    length = 12;
                else if (GameManager.day == 5)
                    length = 20;

                password = (generateRandomLetters(length));
                GameObject.Find("password").GetComponent<TextMeshProUGUI>().text = new string(password);
                break;
        }

        
        //animator.SetInteger("state", animatorINT);

    }

    public void deactivateTaskClicking()
    {
        GameManager.Instance.taskActive = false;
        GetComponent<Button>().interactable = true;
        GetComponent<Image>().raycastTarget = true;
        momentumBar.SetActive(false);
        animator.SetInteger("state", 2);
        inactive(true);

    }

    public void deactivateLecture()
    {
        screen.SetActive(false);
        GameManager.Instance.taskActive = false;
        GameManager.Instance.findingBar_UI.SetActive(false);
        //record how long they watched the lecture
        GetComponent<Button>().interactable = true;
    }

    public static string generateRandomLetters(int num)
    {
        var allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var length = num;

        var randomChars = new char[length];

        for (var i = 0; i < length; i++)
        {
            randomChars[i] = allChars[UnityEngine.Random.Range(0, allChars.Length)];
        }

        return new string(randomChars);
    }

    public void submitTyping()
    {
        //Debug.Log(GameObject.Find("typingTask").GetComponent<TMP_InputField>().text.ToString());
        if (GameObject.Find("typingTask").GetComponent<TMP_InputField>().text == GameObject.Find("typing").GetComponent<taskButtons>().password)
        {
            Debug.Log("correct");
            GameManager.Instance.spoonNotifications("SpoonDecrease_UI");
            GameManager.spoonsINT -= GameObject.Find("typing").GetComponent<taskButtons>().softSpoonCost;
            GameManager.Instance.typingBar_UI.SetActive(false);
            GameObject.Find("typing").GetComponent<taskButtons>().deactivateTaskClicking();
        }
        else
        {
            GameObject.Find("typingTask").GetComponent<Animator>().Play("wrongInput");
            GameManager.Instance.spoonNotifications("SpoonDecrease_UI");
            GameManager.spoonsINT -= GameObject.Find("typing").GetComponent<taskButtons>().hardSpoonCost;
        }
        
    }

    public static string generatePhrase()
    {
        List< string > phrases = new List< string >()
        { 
            "This is the lecture", "Definitely the lecture", "The boring lecture", "lecture", "LECTURE", "THE VERY IMPORTANT LECTURE", "Science Lecture",
            "Totally the lecture", "A Lecture", "Who Lecture?", "What lecture?", "That lecture", "I am not a lecture", "A video maybe relating to a lecture",
            "A video relating to the lecture"
        };

        string phrase = phrases[UnityEngine.Random.Range(0, phrases.Count)];
        return phrase;
    }

    public static string pickAVideo()
    {
        List<string> videos = new List<string>()
        {
            "Videos/noot", "Videos/miku", "Videos/remmi", "Videos/dragon", "Videos/icecream", "Videos/rick"
        };

        string vid = videos[UnityEngine.Random.Range(0, videos.Count)];
        return vid;
    }

    public void inactive(bool sate)
    {
        GameManager.Instance.lookUpBTN.GetComponent<Button>().interactable = sate;
        GameManager.Instance.lookDownBTN.GetComponent<Button>().interactable = sate;
        GameManager.Instance.lookLeftBTN.GetComponent<Button>().interactable = sate;
        GameManager.Instance.lookRightBTN.GetComponent<Button>().interactable = sate;
    }

    
}
