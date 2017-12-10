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

    void Awake()
    {
        _groundedActionState = new GroundedActionState(this);
        _airborneActionState = new AirborneActionState(this);
    }

    void Start ()
    {
        SetActionState(_airborneActionState);
    }
	
	void Update ()
    {
        _currentActionState.Tick();
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
