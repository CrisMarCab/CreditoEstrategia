using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class habilidades : NetworkBehaviour {
    [SerializeField]
    GameObject protagonista;
	// Use this for initialization
	void Start () {
        protagonista = GameObject.Find("protagonista(Clone)");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Velocidad() {
        protagonista.GetComponent<botonCorrer>().CmdVelocidad(true);
    }

    public void Granada()
    {
        protagonista.GetComponent<botonGranada>().CmdLanzaGranada(true);
    }
}
