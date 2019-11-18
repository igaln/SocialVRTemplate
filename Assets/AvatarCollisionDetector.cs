using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class AvatarCollisionDetector : MonoBehaviour
{

    public NetworkedPlayer myPlayerScript;




    private void OnTriggerEnter(Collider other)
    {
        // myPlayerScript.updateLocalPlayerType(1);
        //destory the collider
        myPlayerScript.CmdspawnFireWorks();
    }

  
}
