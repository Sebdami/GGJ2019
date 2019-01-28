using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Hit(float aplhaFadeSpeed = 1.5f, float moveSpeed = 1f, float minAlphaToDestroy = 0.15f)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        if (sr.bounds.Contains(mousePos))
        {
            if(Input.GetMouseButton(0))
            {
                Color col = sr.color;
                col.a -= aplhaFadeSpeed * Time.deltaTime;
                sr.color = col;
                transform.position += ((transform.position - mousePos).normalized) * moveSpeed * Time.deltaTime;
                if (col.a < minAlphaToDestroy)
                    Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        
    }
}
