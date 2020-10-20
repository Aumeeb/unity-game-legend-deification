using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerEventsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int mouseOnCount = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOnCount = mouseOnCount + 1;
        Debug.Log(mouseOnCount);
    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
        }
    }

}