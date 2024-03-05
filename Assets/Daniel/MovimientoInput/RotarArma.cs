using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotarArma : MonoBehaviour
{
    public GameObject arma;
    public float returnTime = 1;

    Vector3 currentRotation;
    Vector3 homeRotation;
    void Start()
    {
        
    }

    public void Gun(InputAction.CallbackContext context)
    {
        float HorizontalAxis = context.ReadValue<Vector2>().x;
        float VerticalAxis = context.ReadValue<Vector2>().y;

        arma.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);

        if (HorizontalAxis == 0 && VerticalAxis == 0)
        {
            currentRotation = arma.transform.localEulerAngles;
            arma.transform.localEulerAngles = Vector3.Slerp(arma.transform.localEulerAngles, homeRotation, Time.deltaTime * returnTime);
        }
        else
        {
            if (HorizontalAxis > 0)
            {
                homeRotation = new Vector3(0f, 0f, 90f);
            }
            else if (HorizontalAxis < 0)
            {
                homeRotation = new Vector3(0f, 0f, -90f);
            }
        }
    }
}
