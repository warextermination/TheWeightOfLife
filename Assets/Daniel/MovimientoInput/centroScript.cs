using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centroScript : MonoBehaviour
{
    public GameObject Victoria;
    public GameObject Centro;
    void Start()
    {
        Centro.transform.position = Victoria.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Centro.transform.position = Victoria.transform.position;
    }
}
