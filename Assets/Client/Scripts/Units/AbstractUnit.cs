using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AbstractUnit : MonoBehaviour
{
    [Inject] protected float _speed;
    [Inject] protected float _finishPos;
    [Inject] protected GameController _gameController;

    void Update()
    {
        if (_gameController.CanMove)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        
    }
}