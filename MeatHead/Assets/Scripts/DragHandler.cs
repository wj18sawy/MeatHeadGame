using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler 
{
    public GameObject Canvas;
    Vector3 startpos;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private GameObject startParent; 

    private void Awake()
    {
        // Search scene for object called Main Canvas
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startpos = transform.position;
        startParent = transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newpos = Input.mousePosition;
        transform.position = newpos;
        transform.SetParent(Canvas.transform, true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
        }
        else
        {
            transform.position = startpos;
            transform.SetParent(startParent.transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject; 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }
}
