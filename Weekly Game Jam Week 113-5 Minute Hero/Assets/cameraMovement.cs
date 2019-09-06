using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{ 
    Rigidbody playerModel;                                                      // The player rigidBody object
    Camera cameraElement;                                                       // The camera
    // Public values related to camera movement
    public float jumpingSpeed = 20.0f;                                          // jumping speed
    public float walkingAcceleration = 1.0f, runningAcceleration = 3.0f;       // Acceleration of movement
    public float decelerationSpeed = 4.0f;                                      // speed of decreasement of velocity when not clicking on any buttons(horizontally, gravity takes care of this otherwise
    public float cameraAngleX = 0, cameraAngleY = 0;                            // Starting orientation of camera
    public float horizontalAngularSpeed = 1.5f, verticalAngularSpeed = 1.5f;    // vertical and horizontal rotaiton speeds
    public float minimumVerticalTilt = -40,  maximumVerticalTilt = 40;          // Angular tilt limits
    public float maximumWalkingVelocity = 5.0f, maximumRunningVelocity = 10.0f; // Maximum velocity
    public bool reverseVertical = false;                                        // bool determining if vertical inout should be reversed

    // private values
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        // Gets elements
        playerModel = GetComponent<Rigidbody>();
        cameraElement = GetComponent<Camera>();
    }

    // Updates movement, will likely be jerky and unrealistic, should probably use...acceleration or something, should google it
    void updateMovement() {
        // Use Time.deltaTime

        // Interesting, no value for acceleration, I will have to keep track of that myself, then, if this were to be used by more then the player it should have been its own script

        // Checks if the character is running
        isRunning = Input.GetKey(KeyCode.LeftControl);

        // figures out which speed should be used once rather than 
        float currentSpeed = isRunning ? runningAcceleration : walkingAcceleration;

        // BUG: when ortating mouse movement is induced, unknown reason

        // Gets inputs and updates speed
        if (Input.GetKey(KeyCode.W))            // Forwards
        {
            playerModel.velocity -= currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))            // Backwards
        {
            playerModel.velocity += currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))            // Left
        {
            playerModel.velocity -= currentSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))            // Right
        {
            playerModel.velocity += currentSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))        // Jump
        {

        }

        // Sets y value into temporary value
        float yValue = playerModel.velocity.y;          // Gets y
        Vector3 tempZeroValue = playerModel.velocity;   // Gets full velocity value
        tempZeroValue.y = 0;                            // sets y to 0 in temp value
        
        // Checks if maximum velocity have been reached and sets acceleration to 0 if it is larger then 0 already
        if (tempZeroValue.magnitude > (isRunning ? maximumRunningVelocity : maximumWalkingVelocity)) {
            tempZeroValue = tempZeroValue.normalized * (isRunning ? maximumRunningVelocity : maximumWalkingVelocity);   // Sets speed to max if it is above maximum
        }

        tempZeroValue.y = yValue;               // Re-integrates the y Valye
        playerModel.velocity = tempZeroValue;   // sets velocity to the updated velocity
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
