using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;

public class PlayerController : MonoBehaviour
{
    public Transform playerSpawns;
    public enum PlayerState
    {
        Moving,
        Paused
    }
    public bool looksToTheLeft;
    public PlayerState State;

    [SerializeField]
    float speed = 10f;

    Rigidbody2D rb;

    public float GetVelocity()
    {
        return rb.velocity.magnitude;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = playerSpawns.GetChild(GameManager.Instance.UnlockedColors).position;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(transform.position.x, camPos.y, camPos.z);
        //Camera.main.GetComponent<CameraFollow>().enabled = true;
    }
    
    void FixedUpdate()
    {
        if(State == PlayerState.Paused)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0f)
            looksToTheLeft = true;
        else if (horizontalInput > 0f)
            looksToTheLeft = false;
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y);
    }
}
