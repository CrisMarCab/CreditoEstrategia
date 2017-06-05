using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Spawner : NetworkBehaviour
{

    public GameObject enemigo, onClick;

    public override void OnStartServer()
    {
        Debug.Log("Server funcional");
        CmdSpawn();
    }
    
    [Command]
    public void CmdSpawn()
    {
        GameObject objectOnClick = Instantiate(onClick, transform.position, transform.rotation);
        NetworkServer.Spawn(objectOnClick);
    }


}
