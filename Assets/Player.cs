using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRangeUp = 2.5f;
    [Tooltip("In m")] [SerializeField] float yRangeDown = 3f;

    [SerializeField] float positionPitchFactor = -6f;
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] float positionYawFactor = 8.5f;
    [SerializeField] float controlYawFactor = 20f;

    [SerializeField] float controlRollFactor = -30f;


    float xThrow, yThrow;

    // Use this for initialization
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRangeDown, yRangeUp);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;

        float rollDueToControlThrow = xThrow * controlRollFactor;
        float roll = rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
