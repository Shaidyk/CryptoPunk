using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public ParticleSystem effect;

    void DestrEffect()
    {
        effect.Play();
    }
}
