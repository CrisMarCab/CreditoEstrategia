using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "EstrategiaiGenial2017";
	private const string gameName = "Habitacion";
	private HostData[] hostlist;

    private void start() {
        /*
        MasterServer.ipAddress = "127.0.0.1";
        MasterServer.port = 10002;
        */

    }

	private void RefreshHostList()
	{
        MasterServer.RequestHostList(typeName);
	}

	void OnMasterserverEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			//Checkea con pollHostList y guarda en hostlist la ultima lista  host recibida (HostList)
			hostlist = MasterServer.PollHostList();
	}

	private void JoinServer(HostData hostdata)
	{
		//Se conecta al servidor que le pasas por parametro
		Network.Connect (hostdata);
	}

	//ocurre al conectarse al servidor
	void OnConnectedToServer()
	{
		Debug.Log ("Conectado al servidor");
	}


	private void StartServer()
	{
        bool useNat = !Network.HavePublicAddress();

		Network.InitializeServer (4, 10002, useNat);
		MasterServer.RegisterHost(typeName, gameName);
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initializied");
	}

    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                StartServer();
            }

            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
            {
                RefreshHostList();
            }
            if (hostlist != null)
            {
                for (int i = 0; i < hostlist.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostlist[i].gameName))
                    {
                        JoinServer(hostlist[i]);
                    }
                }
            }
        }
    }

}