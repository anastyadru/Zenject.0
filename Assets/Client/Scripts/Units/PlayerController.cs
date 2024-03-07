using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : AbstractUnit
{
	[Inject] private PlayerWonSignal _signal;

	protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.y > _finishPos)
            {
                _signal.Fire();
            }
        }
    }

	public class PlayerFabrik : Factory<float, float, GameController, OpponentController>
	{
	
	}
}