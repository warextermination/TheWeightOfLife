using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionEje : MonoBehaviour
{
    public GameObject ejeMira;
    int rotationSpeed = 10000;
    float angulo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current != null && Gamepad.current.rightShoulder.isPressed)
        {
            rotationSpeed = 180;
        }
        else
        {
            rotationSpeed = 5000;
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed)
        {
            angulo = -180;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed)
        {
            angulo = 0;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.up.isPressed)
        {
            angulo = 90;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.down.isPressed)
        {
            angulo = -90;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }

        //Diagonales
        if (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed && Gamepad.current.leftStick.up.isPressed)
        {
            angulo = 135;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed && Gamepad.current.leftStick.down.isPressed)
        {
            angulo = -135;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed && Gamepad.current.leftStick.up.isPressed)
        {
            angulo = 45;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
        if (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed && Gamepad.current.leftStick.down.isPressed)
        {
            angulo = -45;
            ejeMira.transform.rotation = Quaternion.RotateTowards(from: transform.rotation, to: Quaternion.Euler(x: 0, y: 0, z: angulo), maxDegreesDelta: rotationSpeed * Time.deltaTime);
        }
    }
}
