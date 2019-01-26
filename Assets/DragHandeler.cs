using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    Transform firstParent;

    public bool dragOnSurfaces = true;

    private GameObject m_DraggingIcon;
    private RectTransform m_DraggingPlane;
    bool ignoreEndDrag = false;
    public void Start()
    {
        firstParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        itemBeingDragged.transform.SetParent(startParent.root);//mettre objet dans root
        itemBeingDragged.transform.SetAsLastSibling();//mettre objet au dessus de tout le reste
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }
    public void ResetPiece()
    {
        transform.SetParent(firstParent);
        transform.localPosition = Vector3.zero;
        ignoreEndDrag = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if(ignoreEndDrag)
        {
            ignoreEndDrag = false;
            return;
        }
         GetComponent<CanvasGroup>().blocksRaycasts = true;//bouger les parties une fois sur place
         transform.position = startPosition;

           if (transform.parent != startParent && transform.parent != startParent.root)
               transform.position = startPosition;//revenir a sa case de base
           else if (transform.parent == startParent.root)//lui redonner son parent de base apres avoir "fail drag"
             itemBeingDragged.transform.SetParent(startParent);

           itemBeingDragged = null;

    }
}

