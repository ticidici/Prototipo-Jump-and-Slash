using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedActionState : ActionState {

    

    public GroundedActionState(PlayerModel player) : base(player)
    {
    }

    public override void Tick()
    {
    }

    public override void OnStateEnter(ActionState lastState)
    {
        base.OnStateEnter(lastState);
        _player._isLongJump = false;
    }

    public override void OnStateExit(ActionState nextState)
    {
        base.OnStateExit(nextState);
    }

    public override void MovementInput(float x, float y)
    {
        base.MovementInput(x, y);

    }

    public override void OnJumpHighButton()
    {
        base.OnJumpHighButton();
        if (Mathf.Abs(_rigidbody.velocity.x) > 6)
        {
            _rigidbody.velocity += Vector2.up * 9;
        }
        else
        {
            _rigidbody.velocity += Vector2.up * 7.5f;
        }
        //Si dejamos el cambio de estado para ground sensor podemos hacer una transición a jump squat antes de saltar, también sirve por si hay algún obstáculo que te impida saltar
    }

    public override void OnJumpLongButton()
    {
        base.OnJumpLongButton();
        if (_rigidbody.velocity.x != 0)
        {
            _rigidbody.velocity = new Vector2((_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x)) * 12, 6f);
            _player._isLongJump = true;
            Debug.Log("Salto largo");
        }
        else
        {
            OnJumpHighButton();
        }
    }
}
