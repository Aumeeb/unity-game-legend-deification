using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour {

    public float speed = 0.2f;
    public float destroyTime = 3;
    public Vector3 offset = Vector3.zero;
    private RectTransform rectTransform;
    enum DamagePopupColors
    {
        white,
        yellow,

    }
    // Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
        Destroy(gameObject, destroyTime);
	}
     void Update()
    {
        rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + (speed * Time.deltaTime));

    }

}
