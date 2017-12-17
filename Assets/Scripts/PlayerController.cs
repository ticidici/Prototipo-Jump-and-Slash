using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerController : MonoBehaviour {


    private PlayerModel _playerModel;

	void Awake () {
        
        _playerModel = GetComponent<PlayerModel>();
	}
	

	void Update () {

        float x = 0, y = 0;//float por si hubiera mando o para normalizar

        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.JoystickButton0))
        {
            _playerModel._jumpButtonPressed = true;
        }
        else
        {
            _playerModel._jumpButtonPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton0))//Salto normal
        {
            _playerModel.OnJumpHighButton();
        }

        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton2))//Salto largo
        {
            _playerModel.OnJumpLongButton();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        _playerModel.DirectionBindings(x, y);

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            _playerModel.OnReleaseEnergyButton();
        }
    }
}
