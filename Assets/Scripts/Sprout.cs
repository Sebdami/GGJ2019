using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{
    public WinCountDown winCountDown;
    bool isFound = false;
    public float radius = 7f;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Start()
    {
        isFound = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isFound)
        {
            return;
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, radius);
        if(col)
            Debug.Log(col.name);
        if(col == null)
        {
            isFound = true;
            Debug.Log("Sprout discovered");
            GameManager.Instance.WinInSeconds(4f);
            Invoke("StartFade", 1f);
        }
    }

    void StartFade()
    {
        GetComponent<FadeFlower>().Fade();
    }


}
