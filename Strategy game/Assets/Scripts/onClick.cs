using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;


public class onClick : NetworkBehaviour
{
    GameObject habilidades;

    void Start()
    {


    }

    void Update()
    {

        habilidades = GameObject.Find("Llamadordehabilidades");

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hola");
            CmdTaskOnClick();

        }



    }
    [Command]
    void CmdTaskOnClick()
    {
        Debug.Log("Adios");
        habilidades.GetComponent<habilidades>().Velocidad();

    }

}