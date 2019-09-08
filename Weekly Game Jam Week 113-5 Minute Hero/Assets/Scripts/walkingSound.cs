using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingSound : MonoBehaviour
{
    public Transform mainCamera;
    public AudioSource audioWalking;
    
    Vector3 stillmovement = new Vector3(0, 0, 0);
    
    // plays sound if the character's movement is not approximately 0
    void Update()
    {
        // Mutes the osund if the player is still
        audioWalking.mute = mainCamera.GetComponent<Rigidbody>().velocity == stillmovement;
    }
}
