using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameOnSceneLoad : MonoBehaviour
{
    public GameObject GameManagerPrefab;

    void Awake()
    {
        GameManager.Instance.UnlockedColors = 0;
    }
}
