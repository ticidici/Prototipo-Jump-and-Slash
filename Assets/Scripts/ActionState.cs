using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionState{

    protected PlayerModel _player;
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;

    public abstract void Tick();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }

    public virtual void MovementInput(float x, float y)
    {
        Vector2 currentPosition = _player.GetComponent<Transform>().position;
        _player.GetComponent<Transform>().position = currentPosition + Vector2.right * x * 8 * Time.deltaTime;//Coger verlocidad de PowerState
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
