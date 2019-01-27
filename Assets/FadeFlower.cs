using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFlower : MonoBehaviour
{
    public float duration;

    SpriteRenderer bourgeonSr;
    SpriteRenderer fleurSr;

    private void Start()
    {
        bourgeonSr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        fleurSr = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void Fade()
    {
        FadeIn(fleurSr, 1f);
        FadeOut(bourgeonSr, 1f);
    }

    public void FadeOut(SpriteRenderer sr, float duration)
    {
        StopCoroutine("FadeOutCoroutine");
        StartCoroutine(FadeInCoroutine(sr, duration));
    }

    IEnumerator FadeInCoroutine(SpriteRenderer sr, float duration)
    {
        Color color = sr.color;
        color.a = 1f;
        sr.color = color;
        float timer = 0f;
        while (timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / duration);
            sr.color = color;
        }
        color.a = 0f;
        sr.color = color;
    }

    public void FadeIn(SpriteRenderer sr, float duration)
    {
        StopCoroutine("FadeInCoroutine");
        StartCoroutine(FadeOutCoroutine(sr, duration));
    }

    IEnumerator FadeOutCoroutine(SpriteRenderer sr, float duration)
    {
        Color color = sr.color;
        color.a = 0f;
        sr.color = color;
        float timer = 0f;
        while (timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            sr.color = color;
        }
        color.a = 1f;
        sr.color = color;
    }
}
