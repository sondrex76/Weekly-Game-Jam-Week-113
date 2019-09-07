using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cameraObject;

    public float damage = 10f;  // Damage per shot
    public float range = 150f;  // Range for weapon
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Shoots with gun
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            HealthValue enemy = hit.transform.GetComponent<HealthValue>();
            if (enemy != null)
            {
                Debug.Log("TEST");
                enemy.ChangeHealth(-damage);
            }
        }
    }
}
