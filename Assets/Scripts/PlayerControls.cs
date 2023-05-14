using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 20f;
    
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
        float newXPosition = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPosition = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3 (newXPosition, newYPosition, transform.localPosition.z);
    }

}
