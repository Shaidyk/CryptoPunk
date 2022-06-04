using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public float radius = 10f;
    public float radiusAttack = 4f;
    public float hp = 100f;
    NavMeshAgent nav;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            Destroy(gameObject);
        }
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > radius)
        {
            nav.enabled = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Idle");
        }
        if (distance < radius && distance > radiusAttack)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Run");
        }
        if (distance <= radiusAttack)
        {
            nav.enabled = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Shoot");
        }

    }
}
