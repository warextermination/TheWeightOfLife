using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PruebasInputSystem : MonoBehaviour
{
    public Controles _InputActions;
    public InputAction action_move, action_fire, action_dash;

    public PlayerInput playerInput;
    private void OnEnable()
    {
        //action_move = _InputActions.Player.Move;

        action_fire.Enable();
        action_move.Enable();
    }

    private void OnDisable()
    {
        action_fire.Disable();
        action_move.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(InputAction.CallbackContext callbackContext)
    {

    }
}
