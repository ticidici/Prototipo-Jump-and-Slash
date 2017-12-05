using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionState{

    protected float _lastX = 0, _lastY = 0;

    protected PlayerModel _player;
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;

    public abstract void Tick();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }

    public virtual void MovementInput(float x, float y)
    {
        if (_lastX * x < 0)//Derrape
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * 0.5f, _rigidbody.velocity.y);
        }

        if (_lastX != 0 && x == 0)//Parón
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * 0.65f, _rigidbody.velocity.y);
        }
        if (Mathf.Abs(_rigidbody.velocity.x) < 8)
        {
            _rigidbody.AddForce(Vector2.right * x * 15);//AddForce ja té en compte deltaTime
        }

        if (Mathf.Abs(_rigidbody.velocity.x) >= 8)
        {
            _rigidbody.velocity = new Vector2((_rigidbody.velocity.x/Mathf.Abs(_rigidbody.velocity.x)) * 8, _rigidbody.velocity.y); 
        }
        _lastX = x;
        _lastY = y;
    }

    public virtual void OnJumpHighButton() { }

    public virtual void OnJumpLongButton() { }

    public ActionState(PlayerModel player)
    {
        _player = player;
        _rigidbody = _player.GetComponent<Rigidbody2D>();
        _transform = _player.GetComponent<Transform>();
    }
}
