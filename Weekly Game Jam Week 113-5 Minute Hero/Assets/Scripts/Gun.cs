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
    public float range = 150f;              // Range for weapon

    float timeRun = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Shoot and enable light flash
        {
            innerLight.enabled = spotLight.enabled = outerLight.enabled = true;
            Shoot();
        }
        else {                              // Disable light flash
            timeRun += Time.deltaTime;
            if (timeRun >= minimumLightTime)
            {
                innerLight.enabled = spotLight.enabled = outerLight.enabled = false;
                timeRun = 0;
            }
        }
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
                enemy.ChangeHealth(-damage);
            }
        }
    }
}
