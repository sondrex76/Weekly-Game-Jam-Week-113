using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingSound : MonoBehaviour
{
    public AudioSource audio;

    Vector3 previousPosition = new Vector3(0, 0, 0);
    
    // plays sound if the character's movement is not approximately 0
    void Update()
    {
        if (previousPosition != transform.position) // if teh character have moved
        {
            audio.mute = false;

            previousPosition = transform.position;  // updates position
        }
        else
        {
            audio.mute = true;
        }
    }
}
