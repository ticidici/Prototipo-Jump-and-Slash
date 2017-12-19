using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera _camera;

    private float _currentTargetSize;

    public float _zoomVelocity = 0.4f;
    public float _ssj1TargetSize = 6f;
    public float _ssj2TargetSize = 7f;
    public float _ssj3TargetSize = 8f;


    void Awake ()
    {
        _camera = GetComponent<Camera>();
        _currentTargetSize = _ssj1TargetSize;
	}
	
	void Update ()
    {
        float size = _camera.orthographicSize;

        if (_currentTargetSize - size < 0)
        {
            _camera.orthographicSize -= _zoomVelocity * Time.deltaTime;
        }
        else if (_currentTargetSize - size > 0)
        {
            _camera.orthographicSize += _zoomVelocity * Time.deltaTime;
        }

        if (_currentTargetSize != _camera.orthographicSize && Mathf.Abs(_currentTargetSize - size) < _zoomVelocity / 60)
        {
            _camera.orthographicSize = _currentTargetSize;
        }
	}

    public void ChangeCameraTargetSize(int powerLevel)
    {
        if (powerLevel > 0 && powerLevel < 4)
        {
            switch (powerLevel)
            {
                case 1:
                    _currentTargetSize = _ssj1TargetSize;
                    break;
                case 2:
                    _currentTargetSize = _ssj2TargetSize;
                    break;
                case 3:
                    _currentTargetSize = _ssj3TargetSize;
                    break;
            }
        }
    }
}
