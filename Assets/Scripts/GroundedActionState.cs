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
        Debug.Log("Entering grounded");
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
        _rigidbody.velocity += Vector2.up * 8;
        //Change state
        _player.SetActionState(new AirborneActionState(_player));
    }

    public override void OnJumpLongButton()
    {
        base.OnJumpLongButton();
        
        //_rigidbody.AddForce(_longJumpDirection*15);
    }
}
