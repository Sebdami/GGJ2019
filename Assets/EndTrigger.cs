using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class EndTrigger : MonoBehaviour
{
    public NarrationDialogueUI dialogue;
    void OnTriggerEnter2D(Collider2D collider)
    {
        dialogue.StartDialogue("5");
        gameObject.SetActive(false);
    }
}
