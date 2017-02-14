using UnityEngine;
using System.Collections;

public class Goto : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject destinacion;

	// Use this for initialization
	void Start () {

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.updatePosition = true;
		agent.updateRotation = true;

		agent.SetDestination (destinacion.transform.position);
	}

	// Update is called once per frame
	void Update () {
	
	}


}
