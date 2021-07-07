using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public GameObject shot;
    
    Vector2 input;

    private void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    private void HandleAction(InputAction.CallbackContext context) 
    {
        if (context.action.name == "Fire") { OnFire(); }
        
        if (context.action.name == "Move") { OnMove(context); }
    }

    void Update()
    {
        //input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");

        //transform.Translate(input * speed * Time.deltaTime);

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    OnFire();
        //}

        Gamepad gamepad = Gamepad.current;

        transform.Translate(input * speed * Time.deltaTime);

        if (gamepad == null) return;
        //input = gamepad.leftStick.ReadValue();
        
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            // fire action
            OnFire();
        }

        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            // jump action
            OnJump();
        }
    }

    public void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void OnJump()
    {

    }

    public void OnMove(InputValue inputValue) 
    {
        input = inputValue.Get<Vector2>(); 
    }

    public void OnMove(InputAction.CallbackContext context)
    { 
        input = context.ReadValue<Vector2>(); 
    }
}
