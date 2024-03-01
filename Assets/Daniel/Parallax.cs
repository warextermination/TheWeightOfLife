using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector2 previousCameraPosition;
    public float VelocidadParallax;
    private float spriteWidth;
    private float startPosition;

    public float presicion = 1;

    private float moveAmount;
    private float deltaX;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    private void LateUpdate()
    {
        deltaX = (cameraTransform.position.x - previousCameraPosition.x) * VelocidadParallax;
        transform.Translate(new Vector2(deltaX, 0));
        previousCameraPosition.x = cameraTransform.position.x;

        moveAmount = cameraTransform.position.x * (1 - VelocidadParallax);

        if(moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector2(spriteWidth * presicion, 0));
            startPosition += spriteWidth;
        }
        else if(moveAmount < startPosition - spriteWidth)
        {
            transform.Translate(new Vector2(-spriteWidth * presicion, 0));
            startPosition -= spriteWidth;
        }
    }
}
