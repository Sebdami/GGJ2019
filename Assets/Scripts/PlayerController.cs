using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Moving,
        Paused
    }

    public PlayerState State;

    [SerializeField]
    float speed = 10f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(State == PlayerState.Paused)
            return;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}
