using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerUpdate : MonoBehaviour
{
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

        textOverlay.text = minutes + ":" + seconds + ":" + milliseconds;
    }
}
