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

    public event Action Died;

    public event Action TakedMoney;

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
        else if (collision.collider.TryGetComponent(out Let let))
            Died?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Money money))
        {
            Destroy(money.gameObject);

            TakedMoney?.Invoke();
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void Jump(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    private bool JumpPerformed()
    {
        return _input.Player.Jump.phase == InputActionPhase.Performed;
    }
}
