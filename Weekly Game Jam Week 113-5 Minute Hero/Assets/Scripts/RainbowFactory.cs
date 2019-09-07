using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowFactory : MonoBehaviour
{
    public AudioSource cursedSound;
    public AudioClip cursed1;
    public AudioClip cursed2;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1, 10) > 5)
            cursedSound.clip = cursed1;
        else
            cursedSound.clip = cursed2;

        cursedSound.Play(); // Starts playing
    }
}
