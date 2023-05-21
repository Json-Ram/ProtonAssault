using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    [SerializeField] float controlSpeed = 25f;
    [SerializeField] float xRange = 13f;
    [SerializeField] float yRange = 7f;
    [SerializeField] GameObject[] lasers;

    [SerializeField] float positionPitchFactor = -2;
    [SerializeField] float controlPitchFactor = -50f;

    [SerializeField] float positionYawFactor = 1f;

    [SerializeField] float controlRollFactor = -110f;

    float xThrow;
    float yThrow;
    
    void OnEnable()
    {
        movement.Enable();    
        fire.Enable();
    }

    void OnDisable()
    {
        movement.Disable();    
        fire.Enable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;  
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);// so player cannot move off screen / same for y axis

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -yRange, yRange); 

        transform.localPosition = new Vector3 (clampedXPosition, clampedYPosition, transform.localPosition.z);
    }

    void ProcessRotation()
    {   
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(pitch, yaw, roll), Time.deltaTime);
    }

    void ProcessFiring()
    {
        if (fire.ReadValue<float>() > 0.5)
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    void ActivateLasers() 
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
