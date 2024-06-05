using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughts : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.SetParent(GameObject.Find("ThoughtsPanel").transform);
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
