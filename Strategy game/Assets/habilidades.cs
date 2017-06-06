﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class habilidades : NetworkBehaviour
{
    [SerializeField]
    [SyncVar]
    GameObject protagonistaID;
    private NetworkIdentity protagonistaNetID, habilidadesNetId;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PreNet()
    {
        if (!isLocalPlayer)
        {
            protagonistaID = GameObject.Find("protagonista(Clone)");
            CmdPrevioVelocidad(protagonistaID);
        }
    }

    [Command]
    void CmdPrevioVelocidad(GameObject protagonista)
    {
        protagonistaNetID = protagonista.GetComponent<NetworkIdentity>();
        //protagonistaNetID.AssignClientAuthority(connectionToClient);
        RpcVelocidad(protagonista);
        //protagonistaNetID.RemoveClientAuthority(connectionToClient);
    }

    [ClientRpc]
    private void RpcVelocidad(GameObject protagonista)
    {
        protagonistaID.GetComponent<botonCorrer>().CmdVelocidad(true);
    }


    public void CmdGranada()
    {
        protagonistaID.GetComponent<botonGranada>().CmdLanzaGranada(true);
    }
}
