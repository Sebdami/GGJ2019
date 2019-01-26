using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLockedDoor : MonoBehaviour
{
    public int colorToLock = 1;
    void Start()
    {
        if (GameManager.Instance.UnlockedColors >= colorToLock)
        {
            // Disable Blocking Door
            transform.GetChild(0).gameObject.SetActive(false);

            // Enable Open Door
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
