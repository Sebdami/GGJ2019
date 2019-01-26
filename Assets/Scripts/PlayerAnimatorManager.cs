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
        GameManager.Instance.OnColorUnlock += OnColorUnlock;
        OnColorUnlock(GameManager.Instance.UnlockedColors);
    }

    void OnColorUnlock(int color)
    {
        if(anim)
            anim.SetInteger("UnlockedColors", color);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnColorUnlock -= OnColorUnlock;
    }
    void Update()
    {
        anim.SetFloat("velocity", pc.GetVelocity());
        sr.flipX = pc.looksToTheLeft;
    }
}
