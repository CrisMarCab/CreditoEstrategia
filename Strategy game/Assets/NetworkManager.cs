using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "EstrategiaiGenial2017";
	private const string gameName = "Habitacion";
	private HostData[] hostlist ();
	private void RefreshHostList()
	{
		MasterServer.RequestHostList (typeName);
	}
	void OnMasterserverEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			//Checkea con pollHostList y guarda en hostlist la ultima lista  host recibida (HostList)
			hostlist = MasterServer.PollHostList ();
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
		Network.InitializeServer (2, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost (typeName, gameName);
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initializied");
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer) 
		{
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server")) 
			{
				
				StartServer ();
			}
		}
	}

}