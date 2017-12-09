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

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
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
            _rigidbody.velocity += Vector2.up * 8;
        }
        else
        {
            _rigidbody.velocity += Vector2.up * 6.5f;
        }
        //Si dejamos el cambio de estado para ground sensor podemos hacer una transición a jump squat antes de saltar, también sirve por si hay algún obstáculo que te impida saltar
    }

    public override void OnJumpLongButton()
    {
        base.OnJumpLongButton();
        
        //_rigidbody.AddForce(_longJumpDirection*15);
    }
}
