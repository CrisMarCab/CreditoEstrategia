using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;


public class onClick : NetworkBehaviour
{
    GameObject habilidades;

    void Start()
    {
        habilidades = GameObject.Find("Llamadordehabilidades");

        if (Input.touchCount == 1) {
            CmdTaskOnClick();
        }
    }

    [Command]
    void CmdTaskOnClick()
    {
        habilidades.GetComponent<habilidades>().Velocidad();

    }

}