using UnityEngine;
using UnityEngine.Networking;
public class MovimientoCamara : MonoBehaviour {

	private int bordes = 50;
	private int velocidad = 20;
	public GameObject prota;
	private int AnchoPantalla;
	private int AlturaPantalla;
	Vector3 temporal;

    private void Awake()
    {
    }
    void Start ()
	{
		//prota = GameObject.Find("protagonista");
		AnchoPantalla = Screen.width;
		AlturaPantalla = Screen.height;

		temporal = this.transform.position;
		//temporal.x = prota.transform.position.x;
		this.transform.position = temporal;


		temporal = this.transform.position;
		//temporal.y = prota.transform.position.y;
		this.transform.position = temporal;


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
