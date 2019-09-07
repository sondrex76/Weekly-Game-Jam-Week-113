using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErradicationBeam : MonoBehaviour
{
    public float distanceLight;

    public Light outerLight, innerLight, spotLight;

    bool targetFound = false;       // bool to see if the target have been found
    bool playerWithinRange = false; // bool indicating if the player is within range
    float damage = 80;              // The damage taken from a direct hit

    // Update is called once per frame

    private void Start()
    {
        // deactivates all lights until they are supposed to be used
        outerLight.enabled = innerLight.enabled = spotLight.enabled = false;
    }
    void Update()
    {
        // Must always face in the direction of the player on the horizontal plane
        // Must shoot a ray towards the player when they are in range, if they are the chase is on
        // If the player is found, run the soundclip for chargeup
        // Light up light from the erradication beam(point)
        // When the osund ends, shoot the beam, lighting up everything in that general direaction
        // If the player vere in a direct line from the ranged opponent, they take a large amount of damage

        // Well, it places the lights in front of the player, which isn't exactly what it were supposed to do
        Vector3 playerPos = Camera.main.transform.position; // Gets player's position
        playerPos.y = 0;                                    // Sets directional height to 0

        Vector3 direction = (playerPos - transform.position);
        
        transform.LookAt(playerPos);                        // Changes the direction the ranged opponent looks at to that of the player



        transform.position = transform.parent.position + transform.forward * distanceLight;
    }
}
