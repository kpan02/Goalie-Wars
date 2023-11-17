using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class networkPlayerSpawner : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class networkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private Vector3[] spawnerLocations = new Vector3[] {new Vector3(0, 0, 10.0f),
                                                    new Vector3(0, 0, -10.0f)};
    [HideInInspector]
    public GameObject spawnedPlayerPrefab;
    public GameObject XROrigin;

    // public override void OnJoinedRoom()
    // {
    //     base.OnJoinedRoom();
    //     spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    // }

    
    void Start()
    {
        // Ensure that Photon PUN is properly initialized
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogError("Photon is not connected. Make sure to connect before instantiating network players.");
            return;
        }

        // Get a unique spawn position based on the player's ID
        int playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("ID = " + playerID);

        // Ensure the player ID is within the valid range of spawn locations
        if (playerID > 0 && playerID <= spawnerLocations.Length)
        {
            // Instantiate the player prefab at the specified spawn position
            Vector3 position = spawnerLocations[playerID - 1]; // Adjust for zero-based indexing
            XROrigin.transform.position = position;
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid player ID for spawning: " + playerID);
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
*/