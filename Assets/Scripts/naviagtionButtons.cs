using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naviagtionButtons : MonoBehaviour
{
   private Animator animator;
   public void playNavigationAnimation()
    {
        animator = GameObject.Find("Main Camera").GetComponent<Animator>();
        animator.Play(gameObject.name);

        if (gameObject.name == "hallway")
        {
            GameManager.Instance.position = 6;
            GameManager.Instance.outOfRoom();
        }
        else if (gameObject.name == "backLiving")
        {
            GameManager.Instance.position = 0;
            StartCoroutine(backToRoomUI(4));
        }
        else if (gameObject.name == "backBathroom")
        {
            GameManager.Instance.position = 0;
            StartCoroutine(backToRoomUI(5));
        }
    }

    public IEnumerator backToRoomUI(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.outOfRoom();
    }
}
