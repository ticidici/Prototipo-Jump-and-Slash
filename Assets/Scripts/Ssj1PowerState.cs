﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ssj1PowerState : PowerState {

    public Ssj1PowerState(PlayerModel player) : base(player)
    {
        //Ground Movement
        _xGroundAcceleration = 15f;
        _groundReleaseDeceleration = 0.65f;
        _groundSkiddingDeceleration = 0.5f;
        //High Jump initial condition and impulse
        _highJumpGroundVelocityThreshold = 6f;
        _yHighJumpVelocity0 = 7.5f;
        _yHighJumpVelocity1 = 9f;
        //High Jump and falling air drift
        _horizontalAirVelocityThreshold = 6f;
        _losingMomentumGroundVelocityThreshold = 6.5f;
        _airAcceleration0 = 10f;
        _airAcceleration1 = 15f;
        _airAcceleration2 = 12f;
        //Long Jump
        _xLongJumpVelocity = 12f;
        _yLongJumpVelocity = 6f;
        //Gravity Modifiers
        _gravityLowJumpMultiplier = 2f;
        _gravityFallMultiplier = 2.3f;
        //Maximum Speeds
        _xMaxGroundSpeed = 8f;
        _xMaxAirSpeed = 8f;
        _xMaxAirSpeedLongJump = 12f;
        _yMaxAirSpeed = 15f;
    }

    public override void Tick()
    {
    }

    public override void OnStateEnter(PowerState lastState)
    {
        base.OnStateEnter(lastState);
        _player.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
        _player._powerStateInEditor = 0;
    }

    public override void OnStateExit(PowerState nextState)
    {
        base.OnStateExit(nextState);
    }
}