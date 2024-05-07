using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisar : MonoBehaviour
{
    public JugadorInput input;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            input.puedeSaltar = true;
            input.segundoSalto = true;
        }
    }
}
