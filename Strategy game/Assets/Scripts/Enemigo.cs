using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    Animator anim;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    GameObject destino;

    void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destino = GameObject.FindWithTag("Destino");
    }

    // Use this for initialization
    void Start () {
        navMeshAgent.destination = destino.transform.position;
        navMeshAgent.Resume();

    }

    // Update is called once per frame
    void Update () {

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
            }
        }
        
    }
}
