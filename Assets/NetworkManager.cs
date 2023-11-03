using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject JoinAsPigButton;
    public GameObject JoinAsBirdButton;
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
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.AutomaticallySyncScene = true;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
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
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            PV.RPC("RPC_ActivateButtons", RpcTarget.AllBuffered);
        }
    }

    //If you click the join as a pig button
    public void OnJoinAsPigButtonClicked()
    {
        Debug.Log("Join as pig button clicked");

        //Set properties to pig and go to the main scene
        Hashtable props = new Hashtable();
        props.Add("Animal", "Pig");
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        //Change other button text
        TMP_Text buttonText = JoinAsBirdButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Waiting for other player...";
    }


    //If you click the join as a bird button
    public void OnJoinAsBirdButtonClicked()
    {
        Debug.Log("Join as bird button clicked");

        //Set properties to bird
        Hashtable props = new Hashtable();
        props.Add("Animal", "Bird");
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        //Change other button text
        TMP_Text buttonText = JoinAsPigButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Waiting for other player...";
    }

    //If the player's properties were changed, disactivate the button they clicked
    public override void OnPlayerPropertiesUpdate(Player targetPlayer,
        ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if (changedProps.ContainsValue("Pig"))
        {
            PV.RPC("RPC_SetPigButtonInactive", RpcTarget.AllBuffered);
        } else
        {
            PV.RPC("RPC_SetBirdButtonInactive", RpcTarget.AllBuffered);
        }
    }


    void CheckButtonsAndLoadNewScene()
    {
        //Load the intro scene if both buttons were clicked
        if (PhotonNetwork.PlayerList.Length == 2 && PhotonNetwork.IsMasterClient
            && JoinAsPigButton.activeSelf == false
            && JoinAsBirdButton.activeSelf == false)
        {
            PhotonNetwork.LoadLevel("IntroScene");
            Destroy(this);
        }
    }

    [PunRPC]
    public void RPC_ActivateButtons()
    {
        JoinAsPigButton.SetActive(true);
        JoinAsBirdButton.SetActive(true);
        Debug.Log("Buttons activated");

        //Reset button text just in case
        TMP_Text buttonText = JoinAsPigButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Join As Pig";
        TMP_Text buttonText2 = JoinAsBirdButton.GetComponentInChildren<TMP_Text>();
        buttonText2.text = "Join As Bird";
    }

    [PunRPC]
    public void RPC_SetPigButtonInactive()
    {
        JoinAsPigButton.SetActive(false);
        Debug.Log("Pig button disactivated");
        CheckButtonsAndLoadNewScene();
    }

    [PunRPC]
    public void RPC_SetBirdButtonInactive()
    {
        JoinAsBirdButton.SetActive(false);
        Debug.Log("Bird button disactivated");
        CheckButtonsAndLoadNewScene();
    }
} 

