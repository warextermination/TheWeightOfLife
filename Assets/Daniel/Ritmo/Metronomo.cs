using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Metronomo : MonoBehaviour
{

    [SerializeField] private AudioClip chord;
    [SerializeField] private AudioSource metronomo;

    [SerializeField] private AudioClip cancion;


    public float bPM;
    private float segundos = 60;
    public float delay;
    public float offset;
    private float ritmo;

    public bool early;
    public bool autorizo;

    private bool Golpeo;
    private void Awake()
    {
        ritmo = segundos / bPM;
        ritmo = ritmo - offset;
        StartCoroutine(DelayMusica());
        autorizo = false;
    }

    private void FixedUpdate()
    {
        if (Golpeo)
        {
            StartCoroutine(Resaltar());
        }
    }
    private IEnumerator Resaltar()
    {
        Golpeo = false;
        metronomo.PlayOneShot(chord);
        
        //Primer Toma
        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo=true;
        yield return new WaitForSeconds(0.1f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.1f);

        //Segunda Toma
        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo = true;
        yield return new WaitForSeconds(0.1f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.1f);

        //Tercer toma
        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo = true;
        yield return new WaitForSeconds(0.1f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.1f);

        //Cuarta toma
        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo = true;
        yield return new WaitForSeconds(0.1f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.1f);


        Golpeo =true;
    }
    private IEnumerator DelayMusica()
    {
        yield return new WaitForSeconds(1);
        metronomo.PlayOneShot(cancion);
        yield return new WaitForSeconds(delay);
        Golpeo = true;
        
    }
}
