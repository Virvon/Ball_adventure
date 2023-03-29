using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BallAdventure.Input.PlayerInput _input;

    public event Action GameStarted;

    public event Action Jumped;

    public event Action Grounded;

    private Vector2 giz;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new BallAdventure.Input.PlayerInput();
        _input.Enable();

        GameStarted?.Invoke();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        if(JumpPerformed())
            Jumped?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            Grounded?.Invoke();
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void Jump(Vector2 force)
    {
        _rigidbody.AddForce(force);
        giz = force;
        Debug.Log(force);
    }

    private bool JumpPerformed()
    {
        return _input.Player.Jump.phase == InputActionPhase.Performed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(giz.x, giz.y, 0));
    }
}
