using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class parentComment : MonoBehaviour
{
    private TextMeshProUGUI comment;

    string[] commentType = new string[]
    {
        "Stop being lazy", "Why aren't you working?", "You really should focus on your studies?", "Don't you have an exam?", "Are you working on my poster?"
    };

    public IEnumerator commenting()
    {
        yield return new WaitForSecondsRealtime(4);
        Destroy(gameObject);
    }

    private void Awake()
    {
        comment = GetComponentInChildren<TextMeshProUGUI>();
        comment.text = new string(commentType[Random.Range(0, 5)] + " - mood");
        GameManager.commentChance += 2;
        GameManager.moodINT -= 0.1f;
        StartCoroutine(commenting());
    }
}
