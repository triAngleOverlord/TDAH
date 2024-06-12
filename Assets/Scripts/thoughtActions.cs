using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class thoughtActions : MonoBehaviour
{
    public GameObject whichThought;
    

    public void doesAction()
    {
        Destroy(whichThought);
        gameObject.GetComponent<Button>().onClick.RemoveListener(() => gameObject.GetComponent<thoughtActions>().doesAction());
        Destroy(this);
    }

    


}
