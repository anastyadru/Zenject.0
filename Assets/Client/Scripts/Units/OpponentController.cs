using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OpponentController : AbstractUnit
{
	[Inject] private OpponentWonSignal _signal;

    protected override void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.y > _finishPos)
        {
            _signal.Fire();
        }
    }

	public class OpponentFabrik : Factory<float, float, GameController, OpponentController>
	{
	
	}
}