using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingSound : MonoBehaviour
{
    public AudioSource audioWalking;
    public float minDelay = 0.5f;   // Minimum delay

    float currentDelay;
    Vector3 previousPosition = new Vector3(0, 0, 0);
    
    // plays sound if the character's movement is not approximately 0
    void Update()
    {
        if ((previousPosition.x) != (transform.position.x)
            || (previousPosition.z) != (transform.position.z)) // if the character have moved
        {
            currentDelay += Time.deltaTime;

            // Checks if enough time have passed
            if (currentDelay > minDelay)
            {
                previousPosition = transform.position;  // updates position
            }

            audioWalking.mute = false;
        }
        else
        {
            if (currentDelay > minDelay)
            {
                audioWalking.mute = true;
            }
            currentDelay = 0;
        }
        
        // Debug.Log(previousPosition); // Remember to remove this!
    }
}
