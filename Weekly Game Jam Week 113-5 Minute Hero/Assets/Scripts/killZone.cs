using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZone : MonoBehaviour
{
    // whenever something enters the collider it dies
    private void OnTriggerStay(Collider other)
    {
        // divided into two because I am not sure if it is possible to make it into one(even though the function it calls has the exact same name
        if (other.transform.tag == "Enemy")
            other.gameObject.GetComponent<HealthValue>().ChangeHealth(-800);  // Removes 800hp, should insta kill anything
        else if (other.transform.tag == "MainCamera")
            other.gameObject.GetComponent<playerHealth>().ChangeHealth(-800);  // Removes 800hp, should insta kill anything
    }
}
