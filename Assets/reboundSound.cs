using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reboundSound : MonoBehaviour
{
    public AudioSource audioSource;
    private PhotonView photonView;

    void Start()
    {
        // photonView = this.gameObject.GetComponent<PhotonView>();
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        // if (collision.gameObject.CompareTag("SoccerBall"))
        // {
        //     photonView.RPC("PlayGoalPostSound", RpcTarget.AllBuffered);
        // }
    }

    // [PunRPC]
    // void PlayGoalPostSound()
    // {
    //     audioSource.Play();
    // }
}
