using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Gravedad : MonoBehaviour
{
    private Rigidbody2D playerRigibody;
    private SpriteRenderer spriteRenderer;
    public int orientationY = 1;
    private void Awake()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        GravityChange();
    }

    private void GravityChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            orientationY *= -1;
            playerRigibody.gravityScale *= -1;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }
}
