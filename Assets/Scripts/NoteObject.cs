using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                if(tag == "Win")
                {
                    GameManager.Instance.LoadLevel("Main");
                }
                gameObject.SetActive(false);

                GameManager1.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Activator" || other.tag == "Win")
        {
            canBePressed = true;
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager1.instance.NoteMissed();
        }

    }
}
