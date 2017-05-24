using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pruebacorrer : MonoBehaviour {

    private NavMeshAgent agent;
    public float coolDown = 10;
    public float coolDownTimer;

    // Use this for initialization
    void Start () {
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

    public void velocidad(bool boolean)
    {
        if (boolean && coolDownTimer == 0)
        {
            agent.speed = 14f;
            coolDownTimer = coolDown;
        }
    }
}
