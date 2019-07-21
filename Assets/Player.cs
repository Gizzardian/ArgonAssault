using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters/second")] [SerializeField] float xSpeed = 40f;
    [Tooltip("In meters")] [SerializeField] float xRange = 5f;

    [Tooltip("In meters")] [SerializeField] float yRange = 10f;

    [SerializeField] float positionPitchFactor = -5f;

    float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        // set local rotation
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // x-axis   
        // https://www.udemy.com/unitycourse2/learn/lecture/8477780#questions
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        // y-axis
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
}
