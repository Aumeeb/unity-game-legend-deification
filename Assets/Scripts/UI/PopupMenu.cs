using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    private Inventory inventory;
    public RectTransform popUp;
    public float paddingLeft;
   

    private float x,y,z;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clcik");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        var slotPostion = gameObject.transform.position;
      




        Debug.Log("enter");
        inventory = GameObject.Find("GM").GetComponent<Inventory>();
        inventory.ShowBagPopup(gameObject);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        inventory.HidePopUp();
    }

}
