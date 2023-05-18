using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("lasers that to shoot")][SerializeField] GameObject[] lasers;
    [Tooltip("How fast ship goes up and down")][SerializeField] float speed = 50f;
    [Tooltip("")][SerializeField] float rangeX = 12f;
    [SerializeField] float rangeY = 10f;

    [SerializeField] float positionPicthFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontalThrow;
    float verticalThrow;


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPicthFactor;
        float pitchDueToControl = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float xOffset = horizontalThrow * Time.deltaTime * speed;
        float yOffset = verticalThrow * Time.deltaTime * speed;

        float xPos = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(xPos, -rangeX, rangeX);

        float yPos = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(yPos, -rangeY, rangeY);

        transform.localPosition = new Vector3(clampedxPos, clampedyPos, transform.localPosition.z);
    }
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasers(true);
        }
        else
        {
            SetLasers(false);
        }


    }

    private void SetLasers(bool state)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }


}
