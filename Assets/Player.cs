﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters/second")] [SerializeField] float xSpeed = 40f;
    [Tooltip("In meters")] [SerializeField] float xRange = 15f;

    [Tooltip("In meters")] [SerializeField] float xRangeUp = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        // https://www.udemy.com/unitycourse2/learn/lecture/8477780#questions
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        // my try
        float xThrowUp = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffsetUp = xThrowUp * xSpeed * Time.deltaTime;
        float rawXPosUp = transform.localPosition.y + xOffsetUp;
        float clampedXPosUp = Mathf.Clamp(rawXPosUp, -xRangeUp, xRangeUp);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedXPosUp, transform.localPosition.z);

    }
}
