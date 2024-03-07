using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitPositionController
{
    [Inject]
    private GameConfig _config;
    private int _posCounter;

    public Vector3 GetNewPos()
    {
        _posCounter++;
        return _config.StartPos + new Vector3(_posCounter * _config.DistanceBetweenOpponents, 0, 0);
    }

    public void Reset()
    {
        _posCounter = 0;
    }
}