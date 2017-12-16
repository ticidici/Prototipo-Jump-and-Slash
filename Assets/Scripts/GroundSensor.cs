using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour {

    private PlayerModel _player;
    private int _groundColliders = 0;

    void Awake()
    {
        _player = GetComponent<PlayerModel>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Entering new ground");
            if (_groundColliders == 0)
            {
                _groundColliders++;
                _player.SetActionState(_player._groundedActionState);
            }
            else { _groundColliders++; }
            //Debug.Log("Number of grounds colliding: " + _groundColliders);
        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Leaving one ground");
            _groundColliders--;
            if (_groundColliders == 0)
            {
                _player.SetActionState(_player._airborneActionState);
                //Debug.Log("Airborne");
            }
            //Debug.Log("Number of grounds colliding: " + _groundColliders);
        }  
    }
}
