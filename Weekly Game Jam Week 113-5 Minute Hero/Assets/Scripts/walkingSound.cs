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
        currentDelay += Time.deltaTime;

        if (currentDelay > minDelay)
        {
            previousPosition = transform.position;  // updates position
            currentDelay = 0;

            if ((int)(previousPosition.x * 100) != (int)(transform.position.x * 100)
                && (int)(previousPosition.z * 100) != (int)(transform.position.z * 100)) // if the character have moved
            {
                audioWalking.mute = false;
            }
            else
            {
                audioWalking.mute = true;
            }
        }

    }
}
