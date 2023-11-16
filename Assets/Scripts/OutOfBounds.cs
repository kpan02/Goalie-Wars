using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float x, y, z;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoccerBall"))
        {
            other.transform.position = new Vector3(x, y, z);

            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>();
            if (ballRigidbody)
            {
                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.angularVelocity = Vector3.zero;
            }

        }
    }

}
