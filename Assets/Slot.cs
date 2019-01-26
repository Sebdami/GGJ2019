using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class Slot : MonoBehaviour, IDropHandler
{

    public int id;
    public int width = 1;
    public int height = 1;
    
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(id == -1)
        {
            DragHandeler.itemBeingDragged.GetComponent<DragHandeler>().ResetPiece();
            return;
        }
        if (!item && height == DragHandeler.itemBeingDragged.GetComponent<PicturePiece>().height && width == DragHandeler.itemBeingDragged.GetComponent<PicturePiece>().width)
        {
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
        }
    }
}
