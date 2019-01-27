using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMinigameAudio : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic(null);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.gameMusic);
    }
}
