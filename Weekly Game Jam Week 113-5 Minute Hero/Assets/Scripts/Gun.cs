using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cameraObject;
    public Light innerLight;
    public Light outerLight;
    public Light spotLight;
    public AudioSource shootingNoise;

    public float minimumLightTime = 0.1f;   // Minimum time the flash lasts
    public float damage = 10f;              // Damage per shot
    public float range = 15;              // Range for weapon
    public float maxPower = 7.0f;           // Maximum power multiplier
    public float timeMax = 5.0f;            // Time it takes to reach max potency

    float timeRun = 0;
    float multTime = 0;

    // Runs at start
    private void Start()
    {
        allowLights(false);
    }

    // Runs every frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Shoot and enable light flash
        {
            if (!transform.GetComponent<cameraMovement>().isRunning)
            {
                allowLights(true);
                Shoot();
                multTime = 0;
            }
        }
        else {                              // Disable light flash
            timeRun += Time.deltaTime;      // Updates value with minimal lighting time for flash
            multTime += Time.deltaTime;     // Updates timer for how long since last shot
            if (timeRun >= minimumLightTime)
            {
                allowLights(false);
                timeRun = 0;
            }
        }
    }

    // Activates/deactivates lights
    void allowLights(bool set)
    {
        innerLight.enabled = spotLight.enabled = outerLight.enabled = set;
    }

    // Shoots with gun
    void Shoot()
    {
        shootingNoise.Play();
        RaycastHit hit;
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out hit, range))
        {
            HealthValue enemy = hit.transform.GetComponent<HealthValue>();
            if (enemy != null)
            {
                spotLight.transform.position = cameraObject.transform.position;
                spotLight.transform.forward = cameraObject.transform.forward;
                
                // formula allows gun to deal more damage if it have not been used in a little while
                enemy.ChangeHealth(-damage * ((multTime > timeMax) ? maxPower : 1 + (maxPower - 1) * multTime / timeMax));
            }
        }
    }
}
