using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstellationCameraController : MonoBehaviour
{
    [SerializeField]
    Transform winPosition;

    [Space]
    [SerializeField]
    Transform limitLeft;
    [SerializeField]
    Transform limitRight;
    [SerializeField]
    Transform limitTop;
    [SerializeField]
    Transform limitBottom;

    [Space]
    [SerializeField]
    Sprite researchSprite;

    [SerializeField]
    Sprite checkSprite;

    [SerializeField]
    Image scopeImage;
    [Space]
    [SerializeField]
    float speed = 0.75f;

    [SerializeField]
    float minDistanceToWin = 1f;
    [SerializeField]
    float timeToWin = 3f;

    bool WinCountdownStarted = false;

    void Start()
    {
        scopeImage.sprite = researchSprite;
    }
    
    void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized * speed;
        newPos = new Vector3(Mathf.Clamp(newPos.x, limitLeft.position.x, limitRight.position.x), 
                                Mathf.Clamp(newPos.y, limitBottom.position.y, limitTop.position.y),
                                newPos.z);
        transform.position = newPos;

        if(Vector2.Distance(winPosition.position, transform.position) < minDistanceToWin)
        {
            if(!WinCountdownStarted)
            {
                StartCoroutine(WinInSeconds(3f));
                scopeImage.sprite = checkSprite;
            }
        }
        else
        {
            if(WinCountdownStarted)
            {
                WinCountdownStarted = false;
                scopeImage.sprite = researchSprite;
            }
        }
    }

    IEnumerator WinInSeconds(float seconds)
    {
        Debug.Log("Win");
        WinCountdownStarted = true;
        float timer = 0f;
        while(timer < seconds)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            if (!WinCountdownStarted)
                yield break;
        }
        GameManager.Instance.LoadLevel("Main");
    }
}
