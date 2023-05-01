using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public bool isActive;
    public VariableJoystick variableJoystick;
    public static AirplaneController current;

    public float FlySpeed = 5;
    public float YawAmount = 120;
    public float rotateSpeed = 5;

    private float Yaw;

    private void Start()
    {
        current = this;
       // FlySpeed = 0;
    }

    void Update() {

        if (isActive)
        {
            if (GameController.current.airPlaneMovement)
            {
                // move forward
                transform.position += transform.forward * FlySpeed * Time.deltaTime;
        
                // Y ekseninde yukarı aşağı kısıtlama
                float yPosClamp = Mathf.Clamp(transform.position.y, 9.5f, 10.5f);
                transform.position = new Vector3(transform.position.x, yPosClamp, transform.position.z);

                // inputs
                float horizontalInput = variableJoystick.Horizontal;
                float verticalInput = variableJoystick.Vertical;

                // yaw, pitch, roll
                Yaw += horizontalInput * YawAmount * Time.deltaTime;
                float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
                float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

                // apply rotation
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll),rotateSpeed * Time.deltaTime);
            }
        }
    }

}
