using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlsContainer : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.UnpausePlayerController();
        GameManager.Instance.CanInteract = true;
    }

    private void OnDisable()
    {
        GameManager.Instance.PausePlayerController();
        GameManager.Instance.CanInteract = false;
    }
}
