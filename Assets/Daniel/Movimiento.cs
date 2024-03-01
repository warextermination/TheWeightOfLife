using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public Gravedad gravity;
    public Dash dash;
    //Movimiento horizontal
    public float velocidad = 5.0f;
    public GameObject Victoria;

    public Rigidbody2D rb;
    public float fuerzaSalto = 10f;

    private bool puedeSaltar = false;
    private bool segundoSalto = false;

    public bool jumping = false;

    public float tiempoSalto = 1.5F;

    public Vector2 paraBala;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true;
            segundoSalto = true;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.Q) || (Gamepad.current != null && Gamepad.current.leftShoulder.isPressed))
        {
            velocidad = 0;
        }
        else
        {
            velocidad = 5;
        }

        if (Input.GetKey(KeyCode.A) || (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed))
        {
            Victoria.transform.position += Vector3.left * Time.deltaTime * velocidad;
            dash.orientation = -1;

        }
        else if (Input.GetKey(KeyCode.D) || (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed))
        {
            Victoria.transform.position += Vector3.right * Time.deltaTime * velocidad;
            dash.orientation = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) || (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) && (puedeSaltar))
        {
           Saltar();
        }

    }

    void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
    }
}
