using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    float gravity = 0.9f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(GameManager.Instance.State == GameManager.GameState.Paused)
            return;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}
