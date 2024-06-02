using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class findVideo : MonoBehaviour
{
    public VideoPlayer vPlayer;
    public bool hasVideo;

    public void Awake()
    {
        vPlayer = GetComponent<VideoPlayer>();
    }
    public void playVid()
    {
        //toothlessPanel.SetActive(true);
        if (vPlayer.isPlaying == false)
        {
            vPlayer.Play();
            GameObject.Find("watchLecture").GetComponent<taskButtons>().lastestPlayer = vPlayer;
            GameManager.Instance.screen.SetActive(true);
            //GameManager.Instance.findingBar_UI.SetActive(false);
        }
        Debug.Log(vPlayer.clip.ToString());
        if (vPlayer.clip.ToString() == "whistle (UnityEngine.VideoClip)")
        {
            GameManager.spoonsINT -= GameObject.Find("watchLecture").GetComponent<taskButtons>().softSpoonCost;
            //Debug.Log("watching lecture");
            GameManager.Instance.spoonNotifications("spoonDecrease_UI");
        }
        else if (vPlayer.clip.ToString() != "whistle (UnityEngine.VideoClip)")
        {
            GameManager.spoonsINT += 5;////BALANCE
            GameManager.Instance.spoonNotifications("spoonIncrease_UI");
            //Debug.Log("procrastinating");
        }
        
    }

    public void stopVid()
    {
        GameObject.Find("watchLecture").GetComponent<taskButtons>().screen.SetActive(false);
        GameObject.Find("watchLecture").GetComponent<taskButtons>().lastestPlayer.Stop();
        GameManager.Instance.findingBar_UI.SetActive(true);
        //toothlessPanel.SetActive(false);
    }
}
