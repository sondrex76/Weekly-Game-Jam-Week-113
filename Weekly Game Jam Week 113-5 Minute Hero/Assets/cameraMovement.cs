using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Rigidbody cameraBody;
    Camera cameraElement;
    // Public values related to camera movement
    public float cameraSpeed = 5.0f;
    public float cameraAngleX = 0, cameraAngleY = 0;
    public float horizontalAngularSpeed = 1.5f, verticalAngularSpeed = 1.5f;
    public float minimumVerticalTilt = -40,  maximumVerticalTilt = 40;
    public bool reverseVertical = false;

    // Start is called before the first frame update
    void Start()
    {
        // Gets elements
        cameraBody = GetComponent<Rigidbody>();
        cameraElement = GetComponent<Camera>();
    }

    // Updates movement, will likely be jerky and unrealistic, should probably use...acceleration or something, should google it
    void updateMovement() {
        
    }

    // Updates rotation(in other words reads mouse input and rotates around based on it)
    void updateViewDireaction() {
        cameraAngleX += Input.GetAxis("Mouse X");   // Adds horizontal mouse movement
        float newAngle = cameraAngleY + (reverseVertical ? Input.GetAxis("Mouse Y") : -Input.GetAxis("Mouse Y"));

        if (newAngle > maximumVerticalTilt)
            cameraAngleY = maximumVerticalTilt;
        else if (newAngle < minimumVerticalTilt)
            cameraAngleY = minimumVerticalTilt;
        else cameraAngleY = newAngle;

        cameraElement.transform.rotation = Quaternion.Euler(cameraAngleY, cameraAngleX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        updateViewDireaction();
    }
}
