using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour {
    [SerializeField]
    int vida_total = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SerializeField]
    public int getVida_total() {
        return vida_total;
    }
    public void setVida_total(int daño) {
        vida_total -= daño;
    }


}
