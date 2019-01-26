using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    static FadeManager instance;
    public static FadeManager Instance { get => instance; }

    [SerializeField]
    Image FadeImage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public void FadeIn(float duration)
    {
        StopCoroutine("FadeOutCoroutine");
        StartCoroutine(FadeInCoroutine(duration));
    }

    IEnumerator FadeInCoroutine(float duration)
    {
        Color color = FadeImage.color;
        color.a = 1f;
        FadeImage.color = color;
        float timer = 0f;
        while(timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / duration);
            FadeImage.color = color;
        }
        color.a = 0f;
        FadeImage.color = color;
    }

    public void FadeOut(float duration)
    {
        StopCoroutine("FadeInCoroutine");
        StartCoroutine(FadeOutCoroutine(duration));
    }

    IEnumerator FadeOutCoroutine(float duration)
    {
        Color color = FadeImage.color;
        color.a = 0f;
        FadeImage.color = color;
        float timer = 0f;
        while (timer < duration)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            FadeImage.color = color;
        }
        color.a = 1f;
        FadeImage.color = color;
    }
}
