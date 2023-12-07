using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Disconnect : MonoBehaviour
{
    //Leave the room.
    public void DisconectButton()
    {

        PhotonNetwork.LoadLevel(0);
        Destroy(this);
        PhotonNetwork.LeaveRoom();
    }
}
