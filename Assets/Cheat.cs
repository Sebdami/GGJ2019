using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.MinigameWin();
        }
    }
}
