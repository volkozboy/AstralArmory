using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;

public class ParticlePlay : MonoBehaviour
{
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void Particle(){
        particle.Play();
    }
}
