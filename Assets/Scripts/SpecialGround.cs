using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGround : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;
    private PowerGauge _powerGauge;
    private BoxCollider2D _collider;

    private float _r;
    private float _g;
    private float _b;
    private Color _solidColor;
    private Color _transparentColor;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _powerGauge = FindObjectOfType<PowerGauge>();
        if (!_powerGauge) { Debug.LogError("No PowerGauge found", this); }
        _collider = GetComponent<BoxCollider2D>();
    }

	void Start ()
    {
        _r = _spriteRenderer.color.r;
        _g = _spriteRenderer.color.g;
        _b = _spriteRenderer.color.b;
        _solidColor = new Color(_r, _g, _b, 1);
        _transparentColor = new Color(_r, _g, _b, 0.4f);

        if (_powerGauge.GetPowerLevel() == 0)
        {
            _collider.enabled = true;
            _spriteRenderer.color = _solidColor;
        }
        else
        {
            _collider.enabled = false;
            _spriteRenderer.color = _transparentColor;
        }
    }
	
	void Update () {
		
	}

    void OnEnable()
    {
        PowerGauge.OnPowerless += ChangeState;
    }

    void OnDisable()
    {
        PowerGauge.OnPowerless += ChangeState;
    }

    void ChangeState(bool isPowerless)
    {
        if (isPowerless)
        {
            _collider.enabled = true;
            _spriteRenderer.color = _solidColor;
        }
        else
        {
            _collider.enabled = false;
            _spriteRenderer.color = _transparentColor;
        }
    }
}
