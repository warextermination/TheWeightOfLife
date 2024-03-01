using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Dash : MonoBehaviour
{
    [Header("Dash")][SerializeField] private float _dashingTime = 0.2f;

    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _timeCanDash = 2f;
    private bool _canDash = true;
    private bool _dashing = false;
    private float _baseGravity;
    public Rigidbody2D _rb;

    Vector2 VelocidadNormal;

    public int OrientationY = 1;
    public int orientation = 1;
    private int OrientationAux = 1;
    private void Awake()
    {
        _baseGravity = _rb.gravityScale;
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.C) || (Gamepad.current != null && Gamepad.current.leftTrigger.isPressed)) && _canDash)
        {
            VelocidadNormal = _rb.velocity;
            StartCoroutine(ActionDash());
            OrientationAux = orientation;
        }
        if (_dashing)
        {
            _rb.velocity = new Vector2(OrientationAux * _dashForce, _rb.velocity.y );
        }
    }

    private IEnumerator ActionDash()
    {
        _canDash = false;
        _dashing = true;
        yield return new WaitForSeconds(_dashingTime);
        _dashing = false;
        _rb.velocity = VelocidadNormal;
        yield return new WaitForSeconds(_timeCanDash);
        _canDash = true;
    }
}