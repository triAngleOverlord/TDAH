using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButtons : MonoBehaviour
{

    [SerializeField] private int spoonCost;
    [SerializeField] private int spoonRate;

    public void doAction()
    {
        GameManager.spoonsINT -= spoonCost;
        var clone=Instantiate(Resources.Load<GameObject>("SpoonIncrease_UI"), GameObject.Find("StatsPanel").transform);
        StartCoroutine(gainSpoonNotif(clone));
    }

    public IEnumerator gainSpoonNotif(GameObject clone)
    {
        yield return new WaitForSeconds(1);
        Destroy(clone);
    }
}
