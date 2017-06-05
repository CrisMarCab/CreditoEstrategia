using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class botonCorrer : MonoBehaviour
{
    //public GameObject protagonista;
    private NavMeshAgent agent;
    public float coolDown = 10;
    public float coolDownTimer;

    // Use this for initialization
    void Start () {
        //protagonista = NetworkServer.FindLocalObject (gameObject.NetworkIdentity.netId());
        agent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        else if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
            agent.speed = 7f;
        }
    }

    public void CmdVelocidad(bool boolean)
    {
        if (boolean && coolDownTimer == 0)
        {
            agent.speed = 14f;
            coolDownTimer = coolDown;
        }
    }
}
