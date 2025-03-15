using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XboxController : MonoBehaviour
{
    private InputSystem_Actions controls;
    public bool[] buttonPressed = new bool[4];
    public static float bButtonValue;
    public static float yButtonValue;
    public static float xButtonValue;
    public static float aButtonValue;
    public float rampSpeed = 16f; // Speed at which the button values ramp up
    public float smoothTime = 0.8f; // Smooth time for the buttonPressed values

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
    }
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {
        buttonPressed[0] = false;
        buttonPressed[1] = false;
        buttonPressed[2] = false;  
        buttonPressed[3] = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //Assigning the values that ramp and then go to OSCManager to substract from sensor 100 value
        buttonPressed[0] = controls.Player.Attack.IsPressed();
        buttonPressed[1] = controls.Player.Crouch.IsPressed();
        buttonPressed[2] = controls.Player.Interact.IsPressed();
        buttonPressed[3] = controls.Player.Jump.IsPressed();

        xButtonValue = buttonMethod(buttonPressed[0], xButtonValue, rampSpeed);
        bButtonValue = buttonMethod(buttonPressed[1], bButtonValue, rampSpeed);
        yButtonValue = buttonMethod(buttonPressed[2], yButtonValue, rampSpeed); 
        aButtonValue = buttonMethod(buttonPressed[3], aButtonValue, rampSpeed); 
    }

    float buttonMethod(bool buttonPressed, float buttonValue, float rampSpeed)
    {
        if (buttonPressed == true)
        {
            buttonValue += rampSpeed * Time.deltaTime;
        }
        else
        {
            buttonValue = Mathf.Lerp(buttonValue, 0f, Time.deltaTime / smoothTime);
        }
        buttonValue = Mathf.Clamp(buttonValue, 0f, 100f);
        return buttonValue;
    }
}
