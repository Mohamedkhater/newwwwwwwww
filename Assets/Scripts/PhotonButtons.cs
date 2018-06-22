using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour {

    public InputField iv_create_room, iv_join_room;

    public void OnClickCreateRoom()
    {
        if(iv_create_room.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(iv_create_room.text, new RoomOptions() { MaxPlayers = 4 }, null);
            Debug.Log("Room created");

        }

    }

    public void OnClickJoiningRoom()
    {
        PhotonNetwork.JoinRoom(iv_join_room.text);

    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Classroom");
        Debug.Log("JOINED ROOM");
    }


}
