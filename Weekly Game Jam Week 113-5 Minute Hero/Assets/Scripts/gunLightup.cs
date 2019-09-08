using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLightup : MonoBehaviour
{
    // Private values
    public float lightIntensityMultiplier = 7;
    public float minLightIntensityMultiplier = 0;

    // private values
    float currentLightIntensity;    // Current light intensity
    float maxLightIntensity;        // Maximum light intensity
    float minLightIntensity;        // Minimum light sensitivity
    Renderer materialRenderer;
    Color currentColor = new Color(0, 0, 0);
    GunScript gunObject;

    // Start is called before the first frame update
    void Start()
    {
        gunObject = transform.parent.parent.parent.GetComponent<GunScript>();   // Gets gun object
        materialRenderer = GetComponent<Renderer>();                            // Gets material renderer

        maxLightIntensity = gunObject.maxLightMult;                             // Sets max light strength
        minLightIntensity = gunObject.normLightMult;                            // Sets min light strength
    }

    // Update is called once per frame
    void Update()
    {
        currentLightIntensity = gunObject.returnLightIntensityMult();           // gets current light intensity

        currentColor.r = minLightIntensityMultiplier + currentLightIntensity / maxLightIntensity * lightIntensityMultiplier;
        materialRenderer.material.color = currentColor; // Updates color
    }
}
