using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnlevelLoad : MonoBehaviour
{
    public AudioClip music;
    public bool Fade = true;
    void Start()
    {
        if(Fade)
            AudioManager.Instance.Fade(music, 1f);
        else
            AudioManager.Instance.PlayMusic(music);
    }
}
