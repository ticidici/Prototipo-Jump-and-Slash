using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ssj3PowerState : PowerState {

    public Ssj3PowerState(PlayerModel player) : base(player)
    {
        //Ground Movement
        _xGroundAcceleration = 26f;
        _groundReleaseDeceleration = 0.5f;
        _groundSkiddingDeceleration = 0.5f;
        //High Jump initial condition and impulse
        _highJumpGroundVelocityThreshold = 6f;
        _yHighJumpVelocity0 = 13.5f;
        _yHighJumpVelocity1 = 15f;
        //High Jump and falling air drift
        _horizontalAirVelocityThreshold = 6f;
        _losingMomentumGroundVelocityThreshold = 6.5f;
        _airAcceleration0 = 15f;
        _airAcceleration1 = 21f;
        _airAcceleration2 = 18f;
        //Long Jump
        _xLongJumpVelocity = 28f;
        _yLongJumpVelocity = 10f;
        //Gravity Modifiers
        _gravityLowJumpMultiplier = 2f;
        _gravityFallMultiplier = 2.3f;
        //Maximum Speeds
        _xMaxGroundSpeed = 18f;
        _xMaxAirSpeed = 18f;
        _xMaxAirSpeedLongJump = 28f;
        _yMaxAirSpeed = 25f;
    }

    public override void Tick()
    {
    }

    public override void OnStateEnter(PowerState lastState)
    {
        base.OnStateEnter(lastState);
        _player.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
        _player._powerStateInEditor = 0;
    }

    public override void OnStateExit(PowerState nextState)
    {
        base.OnStateExit(nextState);
    }
}
