using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnEnable : MonoBehaviour
{
    [SerializeField]
    AnimationCurve scaleAnim;
    [SerializeField]
    AnimationCurve disableScaleAnim;
    [SerializeField]
    float animTime = 0.5f;
    [SerializeField]
    float targetScale = 1f;

    private void OnEnable()
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        transform.localScale = Vector3.zero;
        float timer = 0f;
        while (timer < animTime)
        {
            yield return null;
            transform.localScale = targetScale * Vector3.one * scaleAnim.Evaluate(timer / animTime);
            timer += Time.unscaledDeltaTime;
        }
        transform.localScale = targetScale * Vector3.one * scaleAnim.Evaluate(1f);
    }

    public void DisableGameObject()
    {
        if(gameObject.activeSelf)
            StartCoroutine(Disapear());
    }

    IEnumerator Disapear()
    {
        transform.localScale = Vector3.one * targetScale;
        float timer = 0f;
        while (timer < animTime)
        {
            yield return null;
            transform.localScale = targetScale * Vector3.one * disableScaleAnim.Evaluate(timer / animTime);
            timer += Time.unscaledDeltaTime;
        }
        transform.localScale = targetScale * Vector3.one * disableScaleAnim.Evaluate(1f);
        gameObject.SetActive(false);
    }
}
