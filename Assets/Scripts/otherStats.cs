using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class otherStats : MonoBehaviour
{
    public static otherStats otherInstance;
    public float sleep; //max 10 BALANCE
    public float hygiene; //max 8
    public float hunger; //max 5
    public float pee; //max 3
    


    public void instantiateThought(int num)
    {
        var firstThought = Instantiate(Resources.Load<GameObject>("thoughtBubble"));
    }
}
