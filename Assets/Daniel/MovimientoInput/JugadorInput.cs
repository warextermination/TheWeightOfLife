using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class JugadorInput : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject SpritesVic;
    public SpriteRenderer spriteRenderer;
    public Bala bala;

    //Variables Dash
    [Header("Dash")][SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashForce = 50f;
    [SerializeField] private float _timeCanDash = 2f;
    private bool _canDash = true;
    private bool _dashing = false;

    [Header("Velocidad de movimiento")]
    //Variable que indica la velocidad horizontal
    static public float horizontal;
    //Variable para la orientación Vertical
    public int orientationY = 1;

    //Velocidad al correr
    [SerializeField] private float velocidad = 6;

    //Variables Salto
    [Header("Salto")]
    public bool puedeSaltar = true;
    public bool segundoSalto = true;
    [SerializeField] private float fuerzaSalto = 10f;
    public GameObject feet;

    //Foco de la cámara
    [Header("Para mover la cámara")]
    public GameObject Foco;
    private bool moviendoC = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            _dashing = false;
        }
        
    }
    void Update()
    {
        
        //movimiento
        transform.Translate(Vector3.right * horizontal * velocidad * Time.deltaTime);
        
        //Espejear Sprite
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
            RotarArma.rotable = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
            RotarArma.rotable = false;
        }


        //Dash
        if (_dashing)
        {
            transform.Translate(Vector3.right * horizontal * _dashForce * 2 * Time.deltaTime);
        }

        if (moviendoC)
        {
            if (orientationY < 0)
            {
                Foco.transform.position += Vector3.down * 10f * Time.deltaTime;
            }
            else
            {
                Foco.transform.position += Vector3.up * 10f * Time.deltaTime;
            }
        }

    }
    public void Salto(InputAction.CallbackContext context)
    {
        if(context.performed && (puedeSaltar || segundoSalto))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto * orientationY);
            if (puedeSaltar == false)
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
            SpritesVic.transform.localScale = new Vector3(1, 1 * orientationY, 1);
            spriteRenderer.flipY = !spriteRenderer.flipY;
            StartCoroutine(moverCamarita());
        }
    }

    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.performed && _canDash)
        {
            StartCoroutine(ActionDash());
        }
    }
    private IEnumerator ActionDash()
    {
        _canDash = false;
        _dashing = true;
        yield return new WaitForSeconds(_dashingTime);
        _dashing = false;
        yield return new WaitForSeconds(_timeCanDash);
        _canDash = true;
    }
    public void StopMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            velocidad = 0;
        }
        else
        {
            velocidad = 6;
        }
    }

    private IEnumerator moverCamarita()
    {
        moviendoC = true;
        yield return new WaitForSeconds(0.5f);
        moviendoC = false;
    }
}
