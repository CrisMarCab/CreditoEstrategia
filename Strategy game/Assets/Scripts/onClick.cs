using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;


public class onClick : NetworkBehaviour
{
    [SerializeField]
    GameObject habilidades, habilidadescliente;
    int id;

    void Start()
    {
        habilidades = GameObject.Find("Llamadordehabilidades");
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hola");
            RpcTaskOnClick(habilidades);

        }



    }

    [ClientRpc]
    void RpcTaskOnClick(GameObject habilidades)
    {
        Debug.Log("Adios");
        habilidades.GetComponent<habilidades>().Velocidad();

    }

}