using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class DragHandler : NetworkBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler 
{
    public GameObject Canvas;
    public GameObject DropZone;
    public PlayerManager PlayerManager;

    Vector3 startpos;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject dropZone;
    private GameObject startParent; 

    private void Start()
    {
        // Search scene for object called Main Canvas
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
        startpos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        startpos = transform.position;
        startParent = transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        Vector3 newpos = Input.mousePosition;
        transform.position = newpos;
        transform.SetParent(Canvas.transform, true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startpos;
            transform.SetParent(startParent.transform);
        }
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
