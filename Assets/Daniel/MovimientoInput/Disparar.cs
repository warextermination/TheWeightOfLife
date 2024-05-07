using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    [SerializeField] AudioClip artimonki;

    public Bala bala;
    public GameObject Victoria1;
    public GameObject miraTemporal;
    public GameObject mirilla;  
    public GameObject bala1;
    public GameObject Auxbala1;
    public Transform spawner;
    public GameObject centro;
    public GameObject centroTemporal;

    private bool posibleDisparo = true;
    public float fuerza = 20f;
    public Vector3 direccionDisparo;
    public bool disparando = false;
    public Vector3 Rodrigo;

    public Metronomo metronomo;

    private bool ordenDisparo = false;

    private void Update()
    {
        if (ordenDisparo)
        {
            accionDisparo();
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(Victoria1 != null)
        {
            if (context.canceled)
            {
                ordenDisparo = false;
                Debug.Log(ordenDisparo);
            }
            if (context.performed)
            {
                if (metronomo.autorizo)
                {
                    accionDisparo();
                    if (context.duration > 1.5f)
                    {
                        ordenDisparo = true;
                        Debug.Log(ordenDisparo);
                    }
                    else
                    {
                        ordenDisparo = false;
                    }
                }
                else
                {
                    ordenDisparo = false;
                    Debug.Log("Destiempo");
                }
            }
        }
    }

    private void accionDisparo()
    {
        if (posibleDisparo && (Victoria1 != null))
        {
            miraTemporal = Instantiate(mirilla, mirilla.transform.position, Quaternion.identity);
            centroTemporal = Instantiate(centro, centro.transform.position, Quaternion.identity);
            direccionDisparo = centroTemporal.transform.position;
            StartCoroutine(Disparando());
            Rodrigo = (direccionDisparo - miraTemporal.transform.position).normalized * Time.deltaTime * fuerza;
            bala.Farias = Rodrigo;
            Auxbala1 = Instantiate(bala1, miraTemporal.transform.position, Quaternion.identity);
            Auxbala1.transform.SetParent(miraTemporal.transform);
            disparando = true;
            ControladorSonido.Instance.ejecutarSonido(artimonki);
            Destroy(miraTemporal, 2f);
            Destroy(centroTemporal, 2f);
            if (Auxbala1 != null)
            {
                Destroy(Auxbala1, 2f);
            }
        }
    }
    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.2f);
        posibleDisparo = true;   
    }

    internal void TomarDaño(float dañoataque)
    {
        throw new NotImplementedException();
    }
}
