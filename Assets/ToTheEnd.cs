using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheEnd : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.LoadLevel("EndScene");
        }
    }
}
