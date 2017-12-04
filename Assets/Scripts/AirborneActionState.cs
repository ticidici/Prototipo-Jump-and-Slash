using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneActionState : ActionState {

    float _fallMultiplier = 2.3f;
    float _lowJumpMultiplier = 2f;

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
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Entering airborne");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }



    public override void MovementInput(float x, float y)
    {
        Vector2 currentPosition = _transform.position;
        _transform.position = currentPosition + Vector2.right * x * 8* 0.8f * Time.deltaTime;//En el aire debería una aceleración, no puedes cambiar de ritmo a la misma velocidad que ya llevas
    }
}
