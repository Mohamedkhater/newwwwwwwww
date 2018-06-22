using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon.Chat;

public class Chatting : MonoBehaviour, IChatClientListener{

    public string versionName = "0.1";

    private ChatClient chatClient;

    private void Awake()
    {
    
        ExitGames.Client.Photon.ConnectionProtocol connectProtocol = ExitGames.Client.Photon.ConnectionProtocol.Udp;
        chatClient = new ChatClient(this, connectProtocol);
        chatClient.ChatRegion = "Asia"; //anywhere else than US and europe

        ExitGames.Client.Photon.Chat.AuthenticationValues authValues = new ExitGames.Client.Photon.Chat.AuthenticationValues();
        authValues.UserId = "uniqueUserNameHere";
        authValues.AuthType = ExitGames.Client.Photon.Chat.CustomAuthenticationType.None;

        chatClient.Connect("3a6c9000-dce8-4bc3-a4f9-c38378ace551", versionName, authValues);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (chatClient != null) { chatClient.Service(); }

    }

    public void OnConnected()
    {
        chatClient.Subscribe(new string[] { "trial" }); //subscribe to chat channel once connected to server
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("Subscribed to a new channel!");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0}{1}={2}, ", msgs, senders[i], messages[i]);
        }
        Debug.Log("OnGetMessages: {0} ({1}) > {2}"+ channelName + senders.Length +msgs);
       
    }

    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
    {
       // throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
       // throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        //throw new System.NotImplementedException();
    }


    public void OnPrivateMessage(string sender, object message, string channelName)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        //throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        //throw new System.NotImplementedException();
    }
}
