using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherStats : MonoBehaviour
{
    public static otherStats otherInstance;
    public float sleep; //max 10 BALANCE
    public float hygiene; //max 8
    public float hunger; //max 5
    public float pee; //max 3
    

    public IEnumerator allStats()
    {
        hygiene -= 0.1f;
        pee -= 0.1f;
        hunger -= 0.1f;
        sleep -= 0.1f;

        yield return new WaitForSecondsRealtime(1);

        //apply thoughts stats at half way and what happens at 0
    }
}
