using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class playingVideos : MonoBehaviour
{
    [SerializeField] private VideoPlayer vPlayer;
    public void playVid()
    {
        //toothlessPanel.SetActive(true);
        if (vPlayer.isPlaying == false)
            vPlayer.Play();
    }

    public void stopVid()
    {
        vPlayer.Stop();
        //toothlessPanel.SetActive(false);
    }
}
