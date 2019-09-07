using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErradicationBeam : MonoBehaviour
{
    public AudioSource shootingNoise;               // AudioSource for shooting noise
    public Light outerLight, innerLight, spotLight; // Lights

    public float distanceLight;                     // Distance of lights from parent object
    public float timeShooting = 7.5f;               // Time it takes for ranged opponents to shoot
    public float erradicationDamage = 80;           // The damage taken from a direct hit
    public float waitingTimeLights = 1.0f;          // Duration of lighting up

    bool targetFound = false;                       // bool to see if the target have been found
    bool lightOn = false;                           // Bool for if the lights areis on
    float timeWaited;                               // The time waited since it were allowed to shoot
    float currentY;                                 // current y of the direction towards the player
    float waitTurnOffLights = 0;                    // time waited since shot went off

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

        // Lets the lights stay on for a certain perios of time
        if (lightOn)
        {
            if (waitTurnOffLights > waitingTimeLights)
            {
                lightOn = outerLight.enabled = innerLight.enabled = spotLight.enabled = false;
                waitTurnOffLights = 0;
            }
            else
            {
                waitTurnOffLights += Time.deltaTime;
            }
        }

        // Well, it places the lights in front of the player, which isn't exactly what it were supposed to do
        Vector3 playerPos = Camera.main.transform.position; // Gets player's position
        currentY = playerPos.y;                             // Sets currentY
        playerPos.y = 0;                                    // Sets directional height to 0
        
        transform.LookAt(playerPos);                        // Changes the direction the ranged opponent looks at to that of the player
        
        transform.position = transform.parent.position + transform.forward * distanceLight;

        if (targetFound)    // Checks if it should start waiting to shoot the player
        {
            timeWaited += Time.deltaTime;
            if (timeWaited >= timeShooting) // If enough time have passed
            {
                // Updates lights
                lightOn = true;
                outerLight.enabled = spotLight.enabled = true;

                RaycastHit hit;

                transform.LookAt(Camera.main.transform.position);   // Gets direction

                // Actual checks
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    playerHealth enemy = hit.transform.GetComponent<playerHealth>();    // Checks if the hit target is the player
                    if (enemy != null)  // If it was indeed the player, they are in range and in direct line of sight to the ranged opponent
                    {
                        enemy.ChangeHealth(-erradicationDamage);    // Updates health
                    }
                }

                // Resets values
                timeWaited = 0;             // Updates time passed
                targetFound = false;        // Updates targetFound
            }
        }
    }

    // Detects if player have entered its range
    private void OnTriggerStay(Collider other)
    {
        if (!targetFound) // checks if the target is already found
            if (other.tag == "MainCamera")
            {
                RaycastHit hit;
                
                transform.LookAt(Camera.main.transform.position);   // Gets direction

                // Actual checks
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.transform.tag == "MainCamera")  // If it was indeed the player, they are in range and in direct line of sight to the ranged opponent
                    {
                        innerLight.enabled = true;
                        shootingNoise.Play();
                        targetFound = true;         // Updates targetFound
                    }
                }
            }
    }
}
