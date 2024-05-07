using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float VelocidadMovimiento;
    [SerializeField] private float Distancia;
    [SerializeField] private LayerMask QueesSuelo;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(VelocidadMovimiento * transform.right.x, rb2D.velocity.y);

        RaycastHit2D informaciondelsuelo = Physics2D.Raycast(transform.position, transform.right, Distancia, QueesSuelo);

        if (informaciondelsuelo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * Distancia);
    }
}
