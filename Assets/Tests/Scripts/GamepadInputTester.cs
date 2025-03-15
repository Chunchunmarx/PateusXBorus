using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadInputTester : MonoBehaviour
{
    [Header("Right Buttons")]
    [SerializeField]
    SpriteRenderer buttonNorth;
    [SerializeField]
    SpriteRenderer buttonSouth;
    [SerializeField]
    SpriteRenderer buttonWest;
    [SerializeField]
    SpriteRenderer buttonEast;

    [SerializeField]
    SpriteRenderer rightShoulder;
    [SerializeField]
    SpriteRenderer rightTrigger;
    [SerializeField]
    SpriteRenderer rightStickButton;
    [SerializeField]
    SpriteRenderer startButton;


    [Header("Left Buttons")]
    [SerializeField]
    SpriteRenderer dpadUp;
    [SerializeField]
    SpriteRenderer dpadDown;
    [SerializeField]
    SpriteRenderer dpadLeft;
    [SerializeField]
    SpriteRenderer dpadRight;

    [SerializeField]
    SpriteRenderer leftShoulder;
    [SerializeField]
    SpriteRenderer leftTrigger;
    [SerializeField]
    SpriteRenderer leftStickButton;
    [SerializeField]
    SpriteRenderer selectButton;

    [SerializeField]
    LineRenderer leftLineRenderer;

    void RightButtons()
    {
        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            Debug.Log("Pressed buttonNorth");
            buttonNorth.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.buttonNorth.wasReleasedThisFrame)
        {
            Debug.Log("Releassed buttonNorth");
            buttonNorth.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Pressed buttonSouth");
            buttonSouth.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
        {
            Debug.Log("Releassed buttonSouth");
            buttonSouth.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            Debug.Log("Pressed buttonWest");
            buttonWest.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.buttonWest.wasReleasedThisFrame)
        {
            Debug.Log("Releassed buttonWest");
            buttonWest.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            Debug.Log("Pressed buttonEast");
            buttonEast.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.buttonEast.wasReleasedThisFrame)
        {
            Debug.Log("Releassed buttonEast");
            buttonEast.color = new Color(1, 0, 0, 1);
        }


        if (Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            Debug.Log("Pressed rightShoulder");
            rightShoulder.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.rightShoulder.wasReleasedThisFrame)
        {
            Debug.Log("Releassed leftShoulder");
            rightShoulder.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            Debug.Log("Pressed rightTrigger");
            rightTrigger.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
        {
            Debug.Log("Releassed rightTrigger");
            rightTrigger.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.rightStickButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed rightStickButton");
            rightStickButton.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.rightStickButton.wasReleasedThisFrame)
        {
            Debug.Log("Releassed rightStickButton");
            rightStickButton.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.startButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed startButton ");
            startButton.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.startButton.wasReleasedThisFrame)
        {
            Debug.Log("Releassed startButton ");
            startButton.color = new Color(1, 0, 0, 1);
        }
    }
    void LeftButtons()
    {
        if (Gamepad.current.dpad.up.wasPressedThisFrame)
        {
            Debug.Log("Pressed dpad.up");
            dpadUp.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.dpad.up.wasReleasedThisFrame)
        {
            Debug.Log("Releassed dpad.up");
            dpadUp.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.dpad.down.wasPressedThisFrame)
        {
            Debug.Log("Pressed dpad.down");
            dpadDown.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.dpad.down.wasReleasedThisFrame)
        {
            Debug.Log("Releassed dpad.down");
            dpadDown.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            Debug.Log("Pressed dpad.left");
            dpadLeft.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.dpad.left.wasReleasedThisFrame)
        {
            Debug.Log("Releassed dpad.left");
            dpadLeft.color = new Color(1, 0, 0, 1);
        }
        if (Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            Debug.Log("Pressed dpad.right");
            dpadRight.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.dpad.right.wasReleasedThisFrame)
        {
            Debug.Log("Releassed dpad.right");
            dpadRight.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.leftShoulder.wasPressedThisFrame)
        {
            Debug.Log("Pressed leftShoulder");
            leftShoulder.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.leftShoulder.wasReleasedThisFrame)
        {
            Debug.Log("Releassed leftShoulder");
            leftShoulder.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.leftTrigger.wasPressedThisFrame)
        {
            Debug.Log("Pressed leftTrigger");
            leftTrigger.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.leftTrigger.wasReleasedThisFrame)
        {
            Debug.Log("Releassed leftTrigger");
            leftTrigger.color = new Color(1, 0, 0, 1);
        }

        if (Gamepad.current.leftStickButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed leftStickButton");
            leftStickButton.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.leftStickButton.wasReleasedThisFrame)
        {
            Debug.Log("Releassed leftStickButton");
            leftStickButton.color = new Color(1, 0, 0, 1);
        }


        if (Gamepad.current.selectButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed selectButton");
            selectButton.color = new Color(0, 1, 0, 1);
        }
        if (Gamepad.current.selectButton.wasReleasedThisFrame)
        {
            Debug.Log("Releassed selectButton");
            selectButton.color = new Color(1, 0, 0, 1);
        }
    }

    void DrawLeftStick()
    {
        return;
        /*
        Vector3 start = transform.position + Vector3.down * 2 + Vector3.left;
        Vector2 temp = Gamepad.current.leftStick.ReadValue();
        Vector3 end = new Vector3(temp.x, temp.y, 0) * 2;
        Debug.DrawLine(start, start + end, Color.red);*/


        LineRenderer  lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f; // Line width at start
        lineRenderer.endWidth = 0.1f;   // Line width at end
        lineRenderer.positionCount = 2; // Number of points

        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Basic material

        // Set line color (only works if using the correct shader)
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        Vector3 start = transform.position + Vector3.down * 2 + Vector3.right;
        Vector2 temp = Gamepad.current.rightStick.ReadValue();
        Vector3 end = new Vector3(temp.x, temp.y, 0) * 2;

        // Set line positions
        lineRenderer.SetPosition(0, start); // Start point
        lineRenderer.SetPosition(1, start + end); // End point
    }
    void DrawRightStick()
    {
        Vector3 start = transform.position + Vector3.down * 2 + Vector3.right;
        Vector2 temp = Gamepad.current.rightStick.ReadValue();
        Vector3 end = new Vector3(temp.x, temp.y, 0) * 2;
        Debug.DrawLine(start, start + end, Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        RightButtons();
        LeftButtons();
        DrawLeftStick();
        DrawRightStick();

        /*
        Debug.Log("Dpad up: " + Gamepad.current.dpad.up);
        Debug.Log("Dpad down: " + Gamepad.current.dpad.down);
        Debug.Log("Dpad left: " + Gamepad.current.dpad.left);
        Debug.Log("Dpad right: " + Gamepad.current.dpad.right);
        */
    }
}
