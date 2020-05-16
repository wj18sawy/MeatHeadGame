using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject zoomCard;

    public void Awake()
    {
        //Canvas = GameObject.Find("Main Canvas");    
    }

    public void OnHoverEnter()
    {
        //zoomCard = Instantiate(gameObject, new Vector2(100, 200), Quaternion.identity);
        //zoomCard.transform.SetParent(Canvas.transform, true);
        //zoomCard.layer = LayerMask.NameToLayer("Zoom");

        //RectTransform rect = zoomCard.GetComponent<RectTransform>();
        //rect.sizeDelta = new Vector2(75, 116); // zoom in 1.5x
    }

    public void OnHoverExit()
    {
        //Destroy(zoomCard);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
