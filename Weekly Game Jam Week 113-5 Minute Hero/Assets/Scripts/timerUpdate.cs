using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerUpdate : MonoBehaviour
{
    public playerHealth player;
    public Text textOverlay;
    float remainingTime = 300;

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;    // updates time value

        // gets minutes, secodns and milliseconds
        int minutes, seconds, milliseconds;
        minutes = (int)remainingTime / 60;
        seconds = (int)remainingTime % 60;
        milliseconds = (int)((remainingTime - (int)remainingTime) * 100);

        if (remainingTime > 0)
        {
            textOverlay.text = minutes + ":" + seconds + ":" + milliseconds;
        }
        else {
            textOverlay.text = "0:00:00";   // Sets Gui to 0:0:00
            player.ChangeHealth(-100);      // Kills player
        }
    }
}
