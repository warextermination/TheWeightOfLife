using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorInput : MonoBehaviour
{

    [Header("Dash")][SerializeField] private float _dashingTime = 0.2f;

    [SerializeField] private float _dashForce = 50f;
    [SerializeField] private float _timeCanDash = 2f;
    private bool _canDash = true;
    private bool _dashing = false;

    public Rigidbody2D rb;

    private float horizontal;
    private float velocidad = 5;
    private float salto = 10f;
    
    private bool puedeSaltar = true;
    private bool segundoSalto = true;

    public SpriteRenderer spriteRenderer;
    public int orientationY = 1;
    Vector2 VelocidadNormal;

    public int OrientationY = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true;
            segundoSalto = true;
        }
    }
    void Update()
    {
        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);

        if (_dashing)
        {
            rb.velocity = new Vector2(horizontal * _dashForce * 2, rb.velocity.y);
        }
    }

    public void Salto(InputAction.CallbackContext context)
    {
        if(context.performed && (puedeSaltar || segundoSalto))
        {
            rb.velocity = new Vector2(rb.velocity.x, salto * orientationY);
            if(puedeSaltar == false)
            {
                segundoSalto = false;
            }
            else
            {
                puedeSaltar = false;
            }
        }
        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1f);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void GravityChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            orientationY *= -1;
            rb.gravityScale *= -1;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }

    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.performed && _canDash)
        {
            VelocidadNormal = rb.velocity;
            StartCoroutine(ActionDash());
        }
    }
    private IEnumerator ActionDash()
    {
        VelocidadNormal = rb.velocity;
        _canDash = false;
        _dashing = true;
        yield return new WaitForSeconds(_dashingTime);
        _dashing = false;
        rb.velocity = VelocidadNormal;
        yield return new WaitForSeconds(_timeCanDash);
        _canDash = true;
    }
}
