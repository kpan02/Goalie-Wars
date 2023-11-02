using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("CK2");
        if (other.gameObject.tag == "SoccerBall")
        {
            scoreManager.IncreaseScoreOne();
            Debug.Log("OK");
        }
    }
}
