using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler 
{
    Vector3 startpos;
    private bool isOverDropZone = false;
    private GameObject dropZone;


    public void OnBeginDrag(PointerEventData eventData)
    {
        startpos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newpos = Input.mousePosition;
        transform.position = newpos;
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
