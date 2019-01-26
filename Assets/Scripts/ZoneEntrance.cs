using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEntrance : MonoBehaviour
{
    public string sceneName;
    public GameObject signCanvas;
    public bool isPlayerInFront = false;

    public void Update()
    {
        if(isPlayerInFront)
        {
            if(Input.GetButtonDown("Jump"))
            {
                GameManager.Instance.LoadLevel(sceneName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            signCanvas.SetActive(true);
            isPlayerInFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            signCanvas.SetActive(false);
            isPlayerInFront = false;
        }
    }
}
