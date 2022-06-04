using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : MonoBehaviour
{
    public ParticleSystem shootEffectLeft;
    public ParticleSystem shootEffectRight;



    void ShootEffectLeft()
    {
        shootEffectLeft.Play();
    }

    void ShootEffectRight()
    {
        shootEffectRight.Play();
    }
}
