using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedObject : NetworkBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        CmdNetworkedDestroy();
    }

    [Command]
    public void CmdNetworkedDestroy()
    {
        Destroy(gameObject);
    }
}
