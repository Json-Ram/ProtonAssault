using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;

    void Start()
    {
        
    }

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

        //Debug.Log(xThrow);
        //Debug.Log(yThrow);    
    }
}
