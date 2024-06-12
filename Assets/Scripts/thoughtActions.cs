using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class thoughtActions : MonoBehaviour, IPointerClickHandler
{
    public GameObject whichThought;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(whichThought);
        Destroy(this);
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }




}
