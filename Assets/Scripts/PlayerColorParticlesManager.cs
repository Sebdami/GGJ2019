using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorParticlesManager : MonoBehaviour
{
    public ParticleSystem ps;
    public Gradient[] Gradients;

    void Start()
    {
        ParticleSystem.MainModule module = ps.main;
        module.startColor = new ParticleSystem.MinMaxGradient(Gradients[GameManager.Instance.UnlockedColors]);
        ps.Play();
    }
}
