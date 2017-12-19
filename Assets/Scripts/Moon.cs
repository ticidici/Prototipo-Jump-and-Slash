using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    public bool _isLastMoon = false;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isLastMoon)
        {
            FindObjectOfType<FinalDoor>().OpenDoor();
        }
        gameObject.SetActive(false);
    }
}
