using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundFade : MonoBehaviour
{
    public GameObject Foreground;
    public float fadeOutTime = 1f;
    public float fadeInTime = 1f;
    bool isFading = false;
    bool playerIsIndoor;

    SpriteRenderer[] foregroundRenderers;

    // Start is called before the first frame update
    void Start()
    {
        playerIsIndoor = false;

        foregroundRenderers = Foreground.GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!playerIsIndoor)
        {
            playerIsIndoor = true;
            if (isFading)
                StopAllCoroutines();
            StartCoroutine(FadeOutForeground(fadeOutTime));
        }
    }

    IEnumerator FadeOutForeground(float duration)
    {
        isFading = true;
        float timer = 0f;

        foreach (SpriteRenderer sr in foregroundRenderers)
        {
            Color color = sr.color;
            color.a = 1f;
            sr.color = color;
        }

        while (timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            foreach (SpriteRenderer sr in foregroundRenderers)
            {
                Color color = sr.color;
                color.a = Mathf.Lerp(1f, 0f, timer / duration);
                sr.color = color;
            }
        }
        
        foreach (SpriteRenderer sr in foregroundRenderers)
        {
            Color color = sr.color;
            color.a = 0f;
            sr.color = color;
        }
        isFading = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerIsIndoor)
        {
            playerIsIndoor = false;
            if (isFading)
                StopAllCoroutines();
            StartCoroutine(FadeInForeground(fadeInTime));
        }
    }

    IEnumerator FadeInForeground(float duration)
    {
        isFading = true;
        float timer = 0f;

        foreach (SpriteRenderer sr in foregroundRenderers)
        {
            Color color = sr.color;
            color.a = 0f;
            sr.color = color;
        }

        while (timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            foreach (SpriteRenderer sr in foregroundRenderers)
            {
                Color color = sr.color;
                color.a = Mathf.Lerp(0f, 1f, timer / duration);
                sr.color = color;
            }
        }

        foreach (SpriteRenderer sr in foregroundRenderers)
        {
            Color color = sr.color;
            color.a = 1f;
            sr.color = color;
        }
        isFading = false;
    }
}
