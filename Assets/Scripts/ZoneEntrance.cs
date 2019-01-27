using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEntrance : MonoBehaviour
{
    public string sceneName;
    public GameObject signCanvas;
    public bool isPlayerInFront = false;
    public int UnlocksColor;

    public void Update()
    {
        if(isPlayerInFront)
        {
            if (!GameManager.Instance.CanInteract)
            {
                signCanvas.SetActive(false);
            }
            else if (signCanvas.activeSelf == false)
                signCanvas.SetActive(true);
            if(Input.GetButtonDown("Jump"))
            {
                GameManager.Instance.LoadLevel(sceneName);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && GameManager.Instance.CanInteract && GameManager.Instance.UnlockedColors == UnlocksColor-1)
        {
            signCanvas.SetActive(true);
            isPlayerInFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            signCanvas.GetComponent<AnimateOnEnable>().DisableGameObject();
            isPlayerInFront = false;
        }
    }
}
