using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private Vector2 _initialPosition;

    public float _despawnTime = 1f;
    public float _respawnTime = 5f;

    private int _unitsPerHit = 3900;

    public delegate void HitAction(int units);
    public static event HitAction OnHit;

    void Awake ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _initialPosition = GetComponent<Transform>().position;
    }

	void Update ()
    {
    }

    public void PropelledOnMe(Vector2 speedVector)
    {
        if (OnHit != null)
        {
            OnHit(_unitsPerHit);
        }

        _collider.enabled = false;
        _rigidbody.velocity = speedVector;
        StartCoroutine(DespawnAndRespawn());
    }

    IEnumerator DespawnAndRespawn()
    {
        yield return new WaitForSeconds(_despawnTime);
        MakeInactive();
        yield return new WaitForSeconds(_respawnTime);
        MakeActive();
    }

    void MakeInactive()
    {
        GetComponent<MeshRenderer>().enabled = false;
        _rigidbody.velocity = Vector2.zero;
    }

    void MakeActive()
    {
        _collider.enabled = true;
        GetComponent<Transform>().position = _initialPosition;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
