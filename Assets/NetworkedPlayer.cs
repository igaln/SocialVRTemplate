using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    [SyncVar]
    public int playerType = 0;

    public GameObject playerCamera;

    public GameObject avatar1;
    public GameObject avatar2;

    public GameObject fireworksPrefab;

    [SyncVar]
    public bool areFireworksOn = false;


    private void Start()
    {
        if(isLocalPlayer == true)
        {
            //enable the camera
            playerCamera.SetActive(true);
        }
        
    }


    //when server connection is established
    public override void OnStartServer()
    {
        base.OnStartServer();

        Debug.Log("on start server");
        Debug.Log("isserver " + isServer);

        if(isServer)
        {
            Debug.Log("net id " + netId);
          
        }

        Debug.Log("on start server end");

    }

    // This only fires on the local client when this player object is network-ready
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();


        Debug.Log("on start local player");

        // apply a shaded background to our player
       // image.color = new Color(1f, 1f, 1f, 0.1f);
    }

    // This fires on all clients when this player object is network-ready
    public override void OnStartClient()
    {
        base.OnStartClient();
        Debug.Log("isserver " + isServer); //if this is a server machine
        Debug.Log("is server only " + isServerOnly); //if this machine acts as a server only
        Debug.Log("is client " + isClient); 
        Debug.Log("is client only " + isClientOnly);
    }


    // Local function to update my player type
    public void updateLocalPlayerType(int type)
    {
        //enforces that only localplayer can choose the player type
        if(isLocalPlayer)
        {
            CmdUpdatePlayerType(type);
        }  
    }

    [Command]
    public void CmdspawnFireWorks()
    {

        //  FindObjectOfType<> fireworks, if it does not exist, spawn

        if(areFireworksOn == false)
        {
            GameObject go = Instantiate(fireworksPrefab);
            //network please, spawn my object
            NetworkServer.Spawn(go);
            areFireworksOn = true;
        }
        
    }

    private void Update()
    {
        if(playerType == 0)
        {
            avatar1.SetActive(true);
            avatar2.SetActive(false);

        } else if(playerType == 1)
        {
            avatar1.SetActive(false);
            avatar2.SetActive(true);
        }
    }

    //Gets executed on the server
    [Command]
    void CmdUpdatePlayerType(int type)
    {
        playerType = type;
    }
}
