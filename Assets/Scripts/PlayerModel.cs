using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour {

    //Hide in inspector
    public bool _jumpButtonPressed = false;

    private ActionState _currentActionState;

    void Start ()
    {
        SetActionState(new AirborneActionState(this));
	}
	
	void Update ()
    {
        _currentActionState.Tick();
	}

    public void SetActionState(ActionState state)
    {
        if (_currentActionState != null)
        {
            _currentActionState.OnStateExit();
        }

        _currentActionState = state;
        gameObject.name = "Jugador - " + state.GetType().Name;

        if (_currentActionState != null)
        {
            _currentActionState.OnStateEnter();
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            SetActionState(new GroundedActionState(this));
        }
    }
}
