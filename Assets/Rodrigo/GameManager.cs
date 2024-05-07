using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int vidas = 3;

    public HUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }

    public void perderVida()
    {
        vidas -= 1;
      if(vidas == 0)
        {
            SceneManager.LoadScene(0);
        }
      
       hud.desactivarVida(vidas);
    }
    public bool recuperarVida()
    {
        if(vidas == 3)
        {
            return false;
        }
        hud.activarVida(vidas);
        vidas += 1;
        return true;
    }
}
