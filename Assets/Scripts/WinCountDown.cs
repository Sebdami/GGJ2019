using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCountDown : MonoBehaviour
{
    Text countdownText;
    [SerializeField]
    AnimationCurve countDownAnim;
    [SerializeField]
    float animTime = 0.5f;
    [SerializeField]
    float targetScale = 1f;

    [SerializeField]
    int secondsToWin = 3;

    int currentSecond;

    private void OnEnable()
    {
        countdownText = GetComponent<Text>();
        currentSecond = secondsToWin;
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while(currentSecond >= 0)
        {
            countdownText.text = currentSecond.ToString();
            StartCoroutine(Appear());
            yield return new WaitForSeconds(1f);
            currentSecond--;
        }
    }

    IEnumerator Appear()
    {
        countdownText.transform.localScale = Vector3.zero;
        float timer = 0f;
        while(timer < animTime)
        {
            yield return null;
            transform.localScale = targetScale * Vector3.one * countDownAnim.Evaluate(timer/animTime);
            timer += Time.unscaledDeltaTime;
        }
        transform.localScale = targetScale * Vector3.one * countDownAnim.Evaluate(1f);
    }


}
