using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroPlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public Boolean enableGyroLogging;
    public Text xAxis;
    public Text yAxis;
    public Text zAxis;
    public Text gyroValues;

    private float startingGyroZaxisValue;
    public float gyroOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            Screen.orientation = ScreenOrientation.Portrait;

            startingGyroZaxisValue = getGyroZAxisValue();
        }

        if (!enableGyroLogging)
        {
            xAxis.enabled = enableGyroLogging;
            yAxis.enabled = enableGyroLogging;
            zAxis.enabled = enableGyroLogging;
            gyroValues.enabled = enableGyroLogging;
        }

    }

    void Update()
    {
        /**
         *  Add sideways force (X Axis) to the rigidbody of the player using the end value
         *  method.
         */
        if(startingGyroZaxisValue == 0)
        {
            startingGyroZaxisValue = getGyroZAxisValue();
        }
        float currentGyroEndValue = CalculateGyroEndValue();
        MobilePlayerMovement(currentGyroEndValue);

        if (enableGyroLogging)
        {
            LogGyroValues(currentGyroEndValue);
        }
    }

    public float getGyroZAxisValue()
    {
        return Input.gyro.attitude.eulerAngles.z;
    }
    private float CalculateGyroEndValue()
    {
        /** 
        *   Calculate the difference between the current z axis position and starting z axis position,
        *   then multiply by deltaTime (time between previous frame and next frame, meaning consistent
        *   movement at any framerate) and multiply by an offset value to control speed.
        */
        float resultantZAxis = (startingGyroZaxisValue - Input.gyro.attitude.eulerAngles.z) * Time.deltaTime * gyroOffset;

        return resultantZAxis;
    }

    public void LogGyroValues(float currentGyroEndValue)
    {
        Vector3 gyroEulerAngles = Input.gyro.attitude.eulerAngles;

        xAxis.text = "X: " + gyroEulerAngles.x;
        yAxis.text = "Y: " + gyroEulerAngles.y;
        zAxis.text = "Z: " + gyroEulerAngles.z;

        gyroValues.text = "Start Value: " + startingGyroZaxisValue + "Gyro current value: " + currentGyroEndValue;
    }

    public void MobilePlayerMovement(float currentGyroEndValue)
    {
        rb.AddForce(currentGyroEndValue, 0, 0);
    }
}
