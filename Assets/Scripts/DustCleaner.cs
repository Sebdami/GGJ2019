using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustCleaner : MonoBehaviour
{
    public float alphaFadeSpeed = 1.5f;
    public float moveSpeed = 1f;
    public float minAlphaToDestroy = 0.15f;
    public ParticleSystem dustParticles;

    bool isPlaying;

    private void Start()
    {
        isPlaying = true;
    }

    void Update()
    {
        if (!isPlaying)
            return;
        if(Input.GetMouseButton(0))
        {
            if (!dustParticles.isPlaying)
                dustParticles.Play();
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.GetComponent<DustParticle>())
                {
                    hit.collider.GetComponent<DustParticle>().Hit(alphaFadeSpeed, moveSpeed, minAlphaToDestroy);
                }
            }
        }
        else if (dustParticles.isPlaying)
            dustParticles.Stop();
    }
}
