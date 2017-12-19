using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
    }
}
