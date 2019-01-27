using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMenu", 4f);
    }

    void LoadMenu()
    {
        GameManager.Instance.LoadLevel("Menu");
    }
}
