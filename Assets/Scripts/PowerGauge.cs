using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGauge : MonoBehaviour {

    public RectTransform _yellowPannel;
    public RectTransform _orangePannel;
    public RectTransform _redPannel;

    private int _maxPowerLevel = 30000;
    //[Range(0,30000)]
    private float _powerLevel = 0;
    private int _dropSpeed = 5*60;//5 per frame, 300 per second

    private Vector3 _dropVector;
    private const int _unitsPerBar = 10000;

    void Start ()
    {
        _redPannel.localScale = new Vector3(0, 1, 0);
        _orangePannel.localScale = new Vector3(0, 1, 0);
        _yellowPannel.localScale = new Vector3(0, 1, 0);

        _dropVector = new Vector3(_dropSpeed / (float)_unitsPerBar, 0, 0);
        //Debug.Log(_dropVector.x.ToString("F4"));
    }
	
	void Update ()
    {
        if (_powerLevel != 0)
        {
            DecreasePower(_dropSpeed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        Enemy.OnHit += IncreasePower;
    }

    void OnDisable()
    {
        Enemy.OnHit -= IncreasePower;
    }

    void IncreasePower(int units)
    {
        _powerLevel += units;
        Debug.Log("" + units + "   " + _powerLevel);
        Debug.Log(((_powerLevel % _unitsPerBar) / _unitsPerBar).ToString("F4"));

        if (_powerLevel > _maxPowerLevel) { _powerLevel = _maxPowerLevel; }

        if (_powerLevel > 2 * _unitsPerBar)
        {
            //Poner barra naranja a 100 y situar roja
            _orangePannel.localScale = new Vector3(1,1,0);
            _redPannel.localScale = new Vector3((_powerLevel % _unitsPerBar)/_unitsPerBar, 1, 0);
        }

        if (_powerLevel > _unitsPerBar)
        {
            //Poner barra amarilla a 100
            _yellowPannel.localScale = new Vector3(1, 1, 0);

            if (_powerLevel <= 2 * _unitsPerBar)
            {
                //Situar barra naranja
                _orangePannel.localScale = new Vector3((_powerLevel % _unitsPerBar) / _unitsPerBar, 1, 0);
            }
        }
        else
        {
            //Situar barra amarilla
            _yellowPannel.localScale = new Vector3((_powerLevel % _unitsPerBar) / _unitsPerBar, 1, 0);
        }

        
    }

    void DecreasePower(float units)
    {
        _powerLevel -= units;

        if (_powerLevel < 0) { _powerLevel = 0; }

        if (_powerLevel > 2 * _unitsPerBar)
        {
            //Situar roja
            _redPannel.localScale = new Vector3((_powerLevel % _unitsPerBar) / _unitsPerBar, 1, 0);
        }
        else
        {
            //Poner barra roja a 0
            _redPannel.localScale = new Vector3(0, 1, 0);

            if (_powerLevel > _unitsPerBar)
            {
                //Situar barra naranja
                _orangePannel.localScale = new Vector3((_powerLevel % _unitsPerBar) / _unitsPerBar, 1, 0);
            }
            else
            {
                //Barra naranja a 0
                _orangePannel.localScale = new Vector3(0, 1, 0);
                //Situar barra amarilla
                _yellowPannel.localScale = new Vector3((_powerLevel % _unitsPerBar) / _unitsPerBar, 1, 0);
            }
        }

    }
}
