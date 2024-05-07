using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;

    private bool pausado =  false;
    public void Pausa(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (pausado)
            {
                pausado = false;
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pausado = true;
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        pausado = false;
        Time.timeScale = 1;
    }
}
