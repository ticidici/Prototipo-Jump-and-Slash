using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour {

    //Hide in inspector (o no, da un poco igual)
    public bool _jumpButtonPressed = false;
    public bool _isLongJump = false;

    public ActionState _currentActionState;
    public ActionState _airborneActionState;
    public ActionState _groundedActionState;

    public PowerState _currentPowerState;
    public PowerState _ssj1PowerState;
    public PowerState _ssj2PowerState;
    public PowerState _ssj3PowerState;

    [Range(0, 3)]
    public int _powerStateInEditor = 0;


    void Awake()
    {
        _groundedActionState = new GroundedActionState(this);
        _airborneActionState = new AirborneActionState(this);

        _ssj1PowerState = new Ssj1PowerState(this);
        _ssj2PowerState = new Ssj2PowerState(this);
        _ssj3PowerState = new Ssj3PowerState(this);
        SetPowerState(_ssj1PowerState);
    }

    void Start ()
    {
        SetActionState(_airborneActionState); 
    }
	
	void Update ()
    {
        _currentActionState.Tick();
        _currentPowerState.Tick();

        if (_powerStateInEditor != 0)
        {
            switch (_powerStateInEditor)
            {
                case 1:
                    SetPowerState(_ssj1PowerState);
                    break;
                case 2:
                    SetPowerState(_ssj2PowerState);
                    break;
                case 3:
                    SetPowerState(_ssj3PowerState);
                    break;
            }
            _currentActionState.RefreshPowerState();
        }

	}

    public void SetActionState(ActionState state)
    {
        if (_currentActionState != null)
        {
            _currentActionState.OnStateExit(state);
        }
        ActionState exitingState = _currentActionState;
        _currentActionState = state;
        gameObject.name = "Jugador - " + state.GetType().Name;

        if (_currentActionState != null)
        {
            _currentActionState.OnStateEnter(exitingState);
        }
    }

    public void SetPowerState(PowerState state)
    {      
        if (_currentPowerState != null)
        {
            _currentPowerState.OnStateExit(state);
        }

        PowerState exitingState = _currentPowerState;
        _currentPowerState = state;

        if (_currentPowerState != null)
        {
            _currentPowerState.OnStateEnter(exitingState);
        }
    }



    public void DirectionBindings(float x, float y)
    {
        _currentActionState.MovementInput(x, y);
    }

    public void OnJumpHighButton()
    {
        _currentActionState.OnJumpHighButton();
    }

    public void OnJumpLongButton()
    {
        _currentActionState.OnJumpLongButton();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Recibir daño
    }
}
