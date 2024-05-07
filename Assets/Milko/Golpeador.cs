using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Golpeador : MonoBehaviour
{
    /*
    private Animator animator;

    private Rigidbody2D rb2d;

    private Transform jugador;

    private bool mirandoderecha = true;

    [Header("Vida")]

    [SerializeField] private float Vida;

    [SerializeField] private vidaPlayer barraDeVida;

    [SerializeField] private Transform controladorAtaque;

    [SerializeField] private float RadioAtaque;

    [SerializeField] private float Dañoataque;



    private void Start(GameObject gameObject)
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarbarraDeVida(Vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void TomarDaño(float Daño)
    {
        Vida -= Daño;

        barraDeVida.CambiarVidaActual(Vida);

        if(Vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }


    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoderecha) || (jugador.position.x < transform.position.x && mirandoderecha))
        {
            mirandoderecha=true;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] obejetos = Physics2D.OverlapCircleAll(controladorAtaque.position, RadioAtaque);

        foreach (Collider2D colision in obejetos)
        {
            if(colision.CompareTag("Player"))
            {
                colision.GetComponent<Disparar>().TomarDaño(Dañoataque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, RadioAtaque);
    }

    */
}