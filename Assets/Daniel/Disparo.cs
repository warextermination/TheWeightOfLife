using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    public Movimiento salto;
    public Gravedad gravity;

    public GameObject bala1;
    public GameObject Auxbala1;

    public Vector3 Apuntador;
    public Vector3 AuxCentro;

    public GameObject centro;
    public GameObject mirilla;

    private bool posibleDisparo = true;

    public float fuerza = -18f;
    public Vector3 direccionDisparo;

    public Rigidbody2D rbBala;

    void Update()
    {
        Apuntador = mirilla.transform.position;
        if (((Gamepad.current != null && Gamepad.current.buttonWest.isPressed) || Input.GetKey(KeyCode.M)) && posibleDisparo)
        {
            disparo();
            StartCoroutine(Disparando());
            Apuntador = mirilla.transform.position;
            AuxCentro = centro.transform.position;
        }
        if (!posibleDisparo)
        {
            Auxbala1.transform.position += direccionDisparo * fuerza * Time.deltaTime;
        }

    }

    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.5f);
        posibleDisparo = true;
        Auxbala1.SetActive(false);
    }

    void disparo()
    {
        direccionDisparo = (centro.transform.position - mirilla.transform.position);
        Auxbala1 = Instantiate(bala1);
        Auxbala1.transform.position = Apuntador;
    }
}
