using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Goal : NetworkBehaviour
{
    public GameObject winner;

    [SyncVar]
    public bool raceCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        winner = other.gameObject;
        if (isServer && raceCompleted == false)
        {
            raceCompleted = true;
            RpcDeclareWinner(winner);
            
        }
        
    }

    [ClientRpc]
    private void RpcDeclareWinner(GameObject winner)
    {
        if (winner.GetComponent<NetworkIdentity>().hasAuthority)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You Lose.");
        }
    }

}
