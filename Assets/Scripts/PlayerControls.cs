using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xRange = 13f;
    [SerializeField] float yRange = 7f;
    
    void OnEnable()
    {
        movement.Enable();    
    }

    void OnDisable()
    {
        movement.Disable();    
    }

    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;  
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange); // so player cannot move off screen / same for y axis

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -yRange, yRange); 

        transform.localPosition = new Vector3 (clampedXPosition, clampedYPosition, transform.localPosition.z);
    }

}
