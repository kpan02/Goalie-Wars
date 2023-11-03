using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkMaster : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomInfo[] rooms;
    public GameObject JoinAsP1Button;
    public GameObject JoinAsP2Button;
    public TMP_Text txtInfo; 
    public TMP_Text txtNumPlayers; 
    private PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
        PV = this.GetComponent<PhotonView>();
    }

    //Connect to the server
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect to Server...");
    }

    public override void OnConnectedToMaster()
    {
        string message = "Connected to master";
        txtInfo.text = message;
        
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.AutomaticallySyncScene = true;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New player joined");
        base.OnPlayerEnteredRoom(newPlayer);

        //Activate the buttons if two people exist
        if (PhotonNetwork.PlayerList.Length >= 1)
        {
            PV.RPC("RPC_ActivateButtons", RpcTarget.AllBuffered);
        }
    }

    //If you click the join as a P1 button
    public void OnJoinAsP1ButtonClicked()
    {
        //Set properties 
        Hashtable props = new Hashtable();
        props.Add("Player", "P1");
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        //Change other button text
        TMP_Text buttonText = JoinAsP2Button.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Waiting for other player...";
    }


    //If you click the join as a P2 button
    public void OnJoinAsP2ButtonClicked()
    {
        //Set properties 
        Hashtable props = new Hashtable();
        props.Add("Player", "P2");
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        //Change other button text
        TMP_Text buttonText = JoinAsP1Button.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Waiting for other player...";
    }

    //If the player's properties were changed, disactivate the button they clicked
    public override void OnPlayerPropertiesUpdate(Player targetPlayer,
        ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if (changedProps.ContainsValue("P1"))
        {
            PV.RPC("RPC_SetP1ButtonInactive", RpcTarget.AllBuffered);
        } else
        {
            PV.RPC("RPC_SetP2ButtonInactive", RpcTarget.AllBuffered);
        }
    }


    void CheckButtonsAndLoadNewScene()
    {
        //Load the intro scene if both buttons were clicked
        if (PhotonNetwork.PlayerList.Length >= 1 && PhotonNetwork.IsMasterClient
            && JoinAsP1Button.activeSelf == false)
        {
            PhotonNetwork.LoadLevel(1); // add variable for int 1 = multiplayscene
            Destroy(this);
        }
    }

    [PunRPC]
    public void RPC_ActivateButtons()
    {
        JoinAsP1Button.SetActive(true);
        JoinAsP2Button.SetActive(true);
        Debug.Log("Buttons activated");

        //Reset button text just in case
        TMP_Text buttonText = JoinAsP1Button.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Join As P1";
        TMP_Text buttonText2 = JoinAsP2Button.GetComponentInChildren<TMP_Text>();
        buttonText2.text = "Join As P2";
    }

    [PunRPC]
    public void RPC_SetP1ButtonInactive()
    {
        JoinAsP1Button.SetActive(false);
        CheckButtonsAndLoadNewScene();
    }

    [PunRPC]
    public void RPC_SetP2ButtonInactive()
    {
        JoinAsP2Button.SetActive(false);
        CheckButtonsAndLoadNewScene();
    }
}