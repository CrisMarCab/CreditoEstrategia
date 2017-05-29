using UnityEngine;

public class MovimientoCamara : MonoBehaviour {

	private int bordes = 50;
	private int velocidad = 20;

	private int AnchoPantalla;
	private int AlturaPantalla;

	Vector3 temporal;

	void Start ()
	{
		AnchoPantalla = Screen.width;
		AlturaPantalla = Screen.height;
	}
	
	void Update () {
		
		if (Input.mousePosition.x > AnchoPantalla - bordes)
		{
			temporal = this.transform.position;
			temporal.z -= velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.x < 0 + bordes){
			temporal = this.transform.position;
			temporal.z += velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.y > AlturaPantalla - bordes){
			temporal = this.transform.position;
			temporal.x += velocidad * Time.deltaTime;
			this.transform.position = temporal;
		}
		if (Input.mousePosition.y < 0 + bordes){
			temporal = this.transform.position;
			temporal.x -= velocidad * Time.deltaTime;
			this.transform.position = temporal;	
		}
	}
}
