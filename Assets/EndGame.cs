using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform slotParent;


    // Update is called once per frame
    void Update()
    {
        bool isDone = true;
        for (int i = 0; i < slotParent.childCount; ++i)
        {
            Slot S = slotParent.GetChild(i).GetComponent<Slot>();
            if (S.transform.childCount == 0) { 
                isDone = false;
                break;
            }
            if (S.id != S.transform.GetChild(0).GetComponent<PicturePiece>().id)
            {
                isDone = false;
                break;
            }
        }
        if(isDone)
        {
            GameManager.Instance.LoadLevel("Main");
        }
    }
}
