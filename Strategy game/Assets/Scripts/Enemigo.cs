using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemigo : NetworkBehaviour
{
    Animator anim;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    GameObject destino;
    private float cooldowntimer, cooldown;
    vida vidaavion;
    vida propia;
    bool daño;
    public AudioClip sonidoDisparo;

    void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destino = GameObject.FindWithTag("Destino");
        cooldowntimer = 1;
        cooldown = cooldowntimer;
    }

    void Start()
    {
        navMeshAgent.destination = destino.transform.position;
        navMeshAgent.Resume();
        GameObject avion = GameObject.Find("destino");
        vidaavion = avion.GetComponent<vida>();
        propia = this.GetComponent<vida>();
        anim.SetInteger("estadoAnimacion", 1);
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(navMeshAgent.transform.position, 10);
        for (var i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Destino")
            {
                navMeshAgent.Stop();
                anim.SetInteger("estadoAnimacion", 0);
                daño = true;
            }
        }

        if (daño)
        {
            anim.SetInteger("estadoAnimacion", -1);

            if (cooldown < 0)
            {
                cooldown = cooldowntimer;
                vidaavion.setVida_total(10);
                AudioSource.PlayClipAtPoint(sonidoDisparo, transform.position, 0.3f);
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }

        if (propia.getVida_total() <= 0)
        {
            anim.SetInteger("estadoAnimacion", -10);
            navMeshAgent.Stop();
            Destroy(this.gameObject, 3);
        }
    }
}
