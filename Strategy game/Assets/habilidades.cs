using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilidades : MonoBehaviour {
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
