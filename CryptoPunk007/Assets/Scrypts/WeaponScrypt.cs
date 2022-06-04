using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScrypt : MonoBehaviour
{
    public float damage = 20;
    public float fireRate = 1.33f;
    public float force = 155f;
    public float range = 15;
    public ParticleSystem gunShotLeftEffect;
    public ParticleSystem gunShotRighttEffect;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnRight;
    public AudioClip shotSFX;
    public AudioSource _aubioSource;
    public GameObject hitEffect;

    private BulletSpawnerR bulletSpavnerR;

    public Camera _camera;

    private float nextShoot = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + 1f / fireRate;
            StartCoroutine(ShootLeft());
            StartCoroutine(ShootRight());
        }
    }

    void ShootEffectLeft()
    {
        _aubioSource.PlayOneShot(shotSFX);
        gunShotLeftEffect.Play();
    }

    void ShootEffectRight()
    {
        Debug.Log(_aubioSource);
        _aubioSource.PlayOneShot(shotSFX);
        gunShotRighttEffect.Play();
    }

    IEnumerator ShootLeft()
    {
        yield return new WaitForSeconds(0.3f);
        ShootEffectLeft();

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log("—“–≈Àﬂﬁ ‚ " + hit.collider.name);

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }

    IEnumerator ShootRight()
    {
        yield return new WaitForSeconds(0.6f);
        ShootEffectRight();

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log("—“–≈Àﬂﬁ ‚ " + hit.collider.name);

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }

}
