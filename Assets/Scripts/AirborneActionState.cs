using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneActionState : ActionState {

    float _fallMultiplier = 2.3f;
    float _lowJumpMultiplier = 2f;

    float _initialXVelocity = 0f;

    public AirborneActionState(PlayerModel player) : base(player)
    {
    }

    public override void Tick()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && _player._jumpButtonPressed == false)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Mathf.Abs(_rigidbody.velocity.y) > 20)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, (_rigidbody.velocity.y / Mathf.Abs(_rigidbody.velocity.y)) * 20);
        }
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        _initialXVelocity = _rigidbody.velocity.x;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }



    public override void MovementInput(float x, float y)
    {
        //a favor del momentum
        if (x * _initialXVelocity > 0)
        {
            if (Mathf.Abs(_rigidbody.velocity.x) < 6)//Si va lento, acelera menos
            {
                _rigidbody.AddForce(Vector2.right * x * 10);
            }
            else if (Mathf.Abs(_rigidbody.velocity.x) >= 6)//Si va rápido, acelera más
            {
                _rigidbody.AddForce(Vector2.right * x * 15);
            }
        }
        else if (x * _initialXVelocity < 0 || _initialXVelocity == 0)//en contra del momentum, sin pulsar nada sigue el arco
        {
            if (Mathf.Abs(_rigidbody.velocity.x) >= 6)//Si va rápuido pierde momentum también rápido
            {
                _rigidbody.AddForce(Vector2.right * x * 15);
            }
            else if (Mathf.Abs(_initialXVelocity) >= 6.5f)//Si ha empezado el salto yendo a mucha velocidad, puede perder momentum más rápido 
            {
                _rigidbody.AddForce(Vector2.right * x * 12);
            }
            else
            {
                _rigidbody.AddForce(Vector2.right * x * 10);
            }
        }

        //Restringir máximo
        if (Mathf.Abs(_rigidbody.velocity.x) > 8)
        {
            _rigidbody.velocity = new Vector2((_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x)) * 8, _rigidbody.velocity.y);
        }

        
 
        _lastX = x;
        _lastY = y;
    }
}
