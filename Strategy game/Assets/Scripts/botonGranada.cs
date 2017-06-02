using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class botonGranada : NetworkBehaviour
{
    public float coolDown = 1;
    public float coolDownTimer;
    public GameObject granadaModelo;
    private GameObject granada;

    void Start()
    {
        granadaModelo.SetActive(false);
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
        }
    }

    [Command]
    public void CmdlanzaGranada(bool boton)
    {
        if (boton && coolDownTimer == 0)
        {
            granada = (GameObject)Instantiate(granadaModelo);
            granada.SetActive(true);

            Vector3 posGranada = transform.TransformPoint(new Vector3(0, 2f, 1f));
            granada.transform.position = posGranada;
            granada.transform.rotation = transform.rotation;
            Rigidbody rb = granada.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0, 300, 750));

            //Destroy(granada, 5);
            coolDownTimer = coolDown;
        }
    }
}
