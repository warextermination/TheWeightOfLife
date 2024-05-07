using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RadialMenu : MonoBehaviour
{
    public GameObject VictoriaBajo;
    public GameObject VictoriaGuitarra;
    public GameObject VictoriaBaquetas;
    public GameObject PuntoCamara;

    public Transform center;
    public Transform selectObject;
    private Vector3 VicPosicion;

    public GameObject RadialMenuRoot;
    public float angleOffset = 30;
    float targetAngle = 0;

    float x = 0;
    float y = 0;

    private bool isRadialMenuActive;
    void Start()
    {
        isRadialMenuActive = false;
    }

    public void ActivarHud(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRadialMenuActive = !isRadialMenuActive;
            if (isRadialMenuActive)
            {
                RadialMenuRoot.SetActive(true);
            }
            else
            {
                RadialMenuRoot.SetActive(false);
                if(targetAngle == 0)
                {
                    cambioBaquetas();
                }
                else if(targetAngle == 120)
                {
                    cambioGuitarra();
                }
                else
                {
                    cambioBajo();
                }
            }
        }
    }

    public void SeleccionarArma(InputAction.CallbackContext context)
    {
        if (isRadialMenuActive)
        {
            Vector2 input = context.ReadValue<Vector2>();
            x = input.x;
            y = input.y;

            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            if (angle < 0)
            {
                angle += 360;
            }

            angle = (angle + angleOffset) % 360;

            int sectionAngle = 120;
            int selectedSection = Mathf.FloorToInt(angle / sectionAngle);

            targetAngle = selectedSection * sectionAngle;
            selectObject.eulerAngles = new Vector3(0, 0, targetAngle);
            Debug.Log(targetAngle);
        }
    }
    private void cambioBaquetas()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaBajo != null)
        {
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }
        else if (VictoriaGuitarra != null)
        {
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        else
        {
            VicPosicion = VictoriaBaquetas.transform.position;
        }

        VictoriaBaquetas.SetActive(true);
        VictoriaBaquetas.transform.position = VicPosicion;
        PuntoCamara.transform.SetParent(VictoriaBaquetas.transform);
    }
    private void cambioGuitarra()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaBajo != null)
        {
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }
        else if (VictoriaBaquetas != null)
        {
            VicPosicion = VictoriaBaquetas.transform.position;
            VictoriaBaquetas.SetActive(false);
        }
        else
        {
            VicPosicion = VictoriaGuitarra.transform.position;
        }

        VictoriaGuitarra.SetActive(true);
        VictoriaGuitarra.transform.position = VicPosicion;
        PuntoCamara.transform.SetParent(VictoriaGuitarra.transform);
    }
    private void cambioBajo()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaGuitarra != null)
        {
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        else if (VictoriaBaquetas != null)
        {
            VicPosicion = VictoriaBaquetas.transform.position;
            VictoriaBaquetas.SetActive(false);
        }
        else
        {
            VicPosicion = VictoriaBajo.transform.position;
        }

        VictoriaBajo.SetActive(true);
        VictoriaBajo.transform.position = VicPosicion;
        PuntoCamara.transform.SetParent(VictoriaBajo.transform);
    }
}