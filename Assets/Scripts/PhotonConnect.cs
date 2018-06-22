using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour {

    public string versionName = "0.1";

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to photon...");
    
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connected to master");

    }

    private void OnJoinedLobby()
    {
        Debug.Log("On joined lobby");

    }

    private void OnDisconnectedFromPhoton()
    {
        Debug.Log("Dis from photon services");
    }

}
