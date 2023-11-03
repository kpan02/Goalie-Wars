using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalOne : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text DebugText;

    void OnTriggerEnter(Collider other)
    {
        // DebugText.text = "Collide";
        if (other.gameObject.tag == "SoccerBall")
        {
            // DebugText.text = "Score";
            scoreManager.IncreaseScoreOne();
        }
    }
}
