using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public Gravedad gravity;
    //Movimiento horizontal
    public float velocidad = 5.0f;
    public GameObject Victoria;

    public Rigidbody2D rb;
    private bool puedeSaltar = true;
    private bool segundoSalto = true;
    private float fuerzaSalto = 10f;
    private float Gravedad = 5f;
    private float velocityY;


    [SerializeField] private float floorheight = 0.5f;
    [SerializeField] Transform feet;
    [SerializeField] ContactFilter2D contactFilter;
    bool isGrounded;
    Collider2D[] results = new Collider2D[1];

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

        }
        else if (Input.GetKey(KeyCode.D) || (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed))
        {
            Victoria.transform.position += Vector3.right * Time.deltaTime * velocidad;
        }


        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            velocityY = Mathf.Sqrt(fuerzaSalto * -2) * (Physics2D.gravity.y * Gravedad);
        }
        velocityY += Physics2D.gravity.y * Gravedad * Time.deltaTime;

        if (Physics2D.OverlapBox(feet.position, feet.localScale, 0, contactFilter, results) > 0 && velocityY < 0)
        {
            velocityY = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorheight;
            Victoria.transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Victoria.transform.Translate(new Vector3(0, velocityY, 0) * Time.deltaTime);
    }
}
