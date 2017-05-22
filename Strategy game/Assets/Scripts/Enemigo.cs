using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{

    Animator anim;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    GameObject destino;
    private float cooldowntimer, cooldown;
    vida vidaavion;
    vida propia;
    bool daño;

    void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destino = GameObject.FindWithTag("Destino");

        cooldowntimer = 1;
        cooldown = cooldowntimer;
    }

    // Use this for initialization
    void Start()
    {
        navMeshAgent.destination = destino.transform.position;
        navMeshAgent.Resume();
        GameObject avion = GameObject.Find("war_plane_interceptor");
        vidaavion = avion.GetComponent<vida>();
        propia = this.GetComponent<vida>();


        anim.SetInteger("estadoAnimacion", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(vidaavion.getVida_total());
        RaycastHit hit;

        Vector3 p1 = transform.position;
        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
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
                vidaavion.setVida_total(20);
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
