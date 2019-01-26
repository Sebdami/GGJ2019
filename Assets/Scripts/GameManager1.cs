using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public AudioSource theMusique;
    public bool startPlaying;
    public PieceScroller theBS;
    public static GameManager1 instance;
    public GameObject OopsieText;
    public ParticleSystem ParticlesWin;

    bool failed = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        OopsieText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(failed)
        {
            if(Input.anyKeyDown)
                GameManager.Instance.LoadLevel("MusiqueGame");
            return;
        }
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.gameObject.SetActive(true);
                theBS.hasStarted = true;

                theMusique.Play();
                
            }
        }
    }
    public void NoteHit()
    {
        
    }
    public void NoteMissed()
    {
        theMusique.Stop();
        theBS.hasStarted = false;
        theBS.gameObject.SetActive(false);
        OopsieText.gameObject.SetActive(true);
        failed = true;

    }
}
