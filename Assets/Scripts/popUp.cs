using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class popUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject popUpPanel;

    private void Start()
    {
        popUpPanel.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        popUpPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popUpPanel.SetActive(false);
    }

    
}
