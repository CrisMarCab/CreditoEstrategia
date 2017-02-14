using UnityEngine;
using System.Collections;

public class MovimientoCamara : MonoBehaviour {

	private int bordes = 30;
	private int velocidad = 10;

	private int AnchoPantalla;
	private int AlturaPantalla;

	Vector3 temporal;

	void Start ()
	{
		AnchoPantalla = Screen.width;
		AlturaPantalla = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.mousePosition.x > AnchoPantalla - bordes)
		{
			temporal = this.transform.position;
			temporal.x += velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.x < 0 + bordes){
			temporal = this.transform.position;
			temporal.x -= velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.y > AlturaPantalla - bordes){
			temporal = this.transform.position;
			temporal.z += velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.y < 0 - bordes){
			temporal = this.transform.position;
			temporal.z -= velocidad * Time.deltaTime;
			this.transform.position = temporal;	
		}
	}

	/*
	void OnGUI ()
	{
		GUI.Box( new Rect( (Screen.width /2) - 140, 5, 280, 25), "Mouse position = " + 
			Input.mousePosition);

		GUI.Box(new Rect( (Screen.width /2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + 
			Input.mousePosition.x);	

		GUI.Box( new Rect( (Screen.height /2) - 10, Screen.height - 10, 140, 25), "Mouse Y = " + 
			Input.mousePosition.y);	

	}*/
}
