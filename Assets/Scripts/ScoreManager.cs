using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreOneText; // Player One Score text
    public TMP_Text scoreTwoText; // Player Two Score text

    private int scoreOne = 0; // Player One Score counter
    private int scoreTwo = 0; // Player Two Score counter
    private int win = 5; // goals needed to win

    public ParticleSystem ribbons;

    private PhotonView photonView;

    void Start()
    {
        photonView = this.gameObject.GetComponent<PhotonView>();
    }

    // Call this method to increase the score for Player One.
    public void IncreaseScoreOne()
    {
        photonView.RPC("RPC_IncreaseScoreOne", RpcTarget.AllBuffered);
    }

    // Call this method to increase the score for Player Two.
    public void IncreaseScoreTwo()
    {
        photonView.RPC("RPC_IncreaseScoreTwo", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void RPC_IncreaseScoreOne()
    {
        scoreOne++;
        // UpdateScoreText();
        scoreOneText.text = scoreOne.ToString();

        if (scoreOne >= win) {
            ribbons.Play();
        };
    }

    [PunRPC]
    void RPC_IncreaseScoreTwo()
    {
        scoreTwo++;
        // UpdateScoreText();
        scoreTwoText.text = scoreTwo.ToString();

        if (scoreTwo >= win) {
            ribbons.Play();
        }
    }
}
