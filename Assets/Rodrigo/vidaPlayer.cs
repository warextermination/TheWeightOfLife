using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPlayer : MonoBehaviour
{
    internal void CambiarVidaActual(float vida)
    {
        throw new NotImplementedException();
    }

    internal void InicializarbarraDeVida(float vida)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = GameManager.Instance.recuperarVida();
            Destroy(this.gameObject);
        }
    }
}
