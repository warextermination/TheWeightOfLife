using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltar : MonoBehaviour
{
    public float jumpHeight = 8.0f;
    public float jumpDuration = 0.5f;
    public LayerMask groundLayer; // Capa para detectar el suelo

    private bool isJumping = false;
    private float jumpTimer = 0.0f;
    private Vector2 startPosition;

    void Update()
    {
        // Verificar si el personaje está en el suelo

        // Salto
        if (Input.GetKey(KeyCode.J))
        {
            transform.position += Vector3.up * jumpHeight * Time.deltaTime;
        }
    }
}