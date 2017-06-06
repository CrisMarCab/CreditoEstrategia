using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediarioHab : MonoBehaviour {

    GameObject protagonistaID;

    public void Velocidad()
    {
        protagonistaID.GetComponent<botonCorrer>().CmdVelocidad(true);
    }

	// Use this for initialization
	void Start () {
        protagonistaID = GameObject.Find("protagonist(Clone)");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
