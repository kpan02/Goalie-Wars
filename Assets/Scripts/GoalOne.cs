using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalOne : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;
    private int win = 5;

    public ParticleSystem ribbons;
    public ParticleSystem fireworks1;
    public AudioSource audioSource;
    private PhotonView photonView;

    private bool goalCooldown = false; // prevent multiple scoring from a single event
    private float cooldownTime = 2.0f; // time for which the goal is in cooldown

    void Start()
    {
        photonView = this.gameObject.GetComponent<PhotonView>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!goalCooldown && other.gameObject.CompareTag("SoccerBall") && gameObject.CompareTag("GoalOne"))
        {
            if (PhotonNetwork.IsMasterClient) // score handling by MasterClient
            {
                IncreaseScore();
                audioSource.Play();
                fireworks1.Play();
            }
        }
    }

    void IncreaseScore()
    {
        score++;
        photonView.RPC("RPC_UpdateScore", RpcTarget.AllBuffered, score);

        StartCoroutine(GoalCooldown());
    }

    [PunRPC]
    void RPC_UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = score.ToString();

        if (score >= win) {
            ribbons.Play();
        }
    }

    IEnumerator GoalCooldown()
    {
        goalCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        goalCooldown = false;
    }
}
