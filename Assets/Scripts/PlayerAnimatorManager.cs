using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    Animator anim;
    PlayerController pc;
    SpriteRenderer sr;

    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        anim.SetFloat("velocity", pc.GetVelocity());
        sr.flipX = pc.looksToTheLeft;
    }
}
