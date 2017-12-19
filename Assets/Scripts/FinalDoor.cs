using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FinalDoor : MonoBehaviour {

    public float _velocity = 2f;


    public void OpenDoor()
    {
        Debug.Log("Door opening");
        GetComponent<Rigidbody2D>().velocity = Vector2.left * _velocity;
        StartCoroutine(DeactivateDoor());
    }

    IEnumerator DeactivateDoor()
    {
        yield return new WaitForSeconds(14);
        gameObject.SetActive(false);
    }
}
