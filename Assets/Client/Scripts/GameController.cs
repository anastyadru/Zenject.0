using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove;
    
    [Inject] private TimeController _timeController;
    [Inject] private UnitPositionController _positionController;
    [Inject] private GameObject _finishPrefab;
	[Inject] private GameConfig _gameConfig;
	[Inject] private OpponentController.OpponentFabrik _opponentFabrik;
	[Inject] private PlayerController.PlayerFabrik _playerFabrik;
	[Inject] private PlayerWonSignal _playerWonSignal;
	[Inject] private OpponentWonSignal _opponentWonSignal;
	[Inject] private GameStartedSignal _gameStartedSignal;
	[Inject] private GameFinishedSignal _gameFinishedSignal;

	public GameObject Player;
	public GameObject[] Opponents;

	private void Start()
	{
		_gameFinishedSignal.Fire();
		_playerWonSignal.Listen(PlayerWonEvent);
		_opponentWonSignal.Listen(OpponentWonEvent);
    }

	private void PlayerWonEvent()
	{
		Debug.Log("Player won");
		_timeController.SetPauseOn();
		OnGameEnd();
	}

	private void OpponentWonEvent()
	{
		Debug.Log("Opponent won");
		_timeController.SetPauseOn();
		OnGameEnd();
	}

	private void OnGameEnd()
	{
		_gameFinishedSignal.Fire();
	}

	void OnApplicationQuit()
	{
		_playerWonSignal.UnListen(PlayerWonEvent);
		_opponentWonSignal.UnListen(OpponentWonEvent);
	}

    public void Play()
    {
		CreateFinish();

		_positionController.Reset();
		CreatePlayers();
		CreateOpponents();

		_timeController.SetPauseOff();

		_gameStartedSignal.Fire();
    }

	private void CreateOpponents()
	{
		if (Opponents == null || !Opponents.Any())
		{
			Opponents = new GameObject[_gameConfig.OpponentsCount];
			for (int i = 0; i < _gameConfig.OpponentsCount; i++)
			{
				Opponents[i] = _opponentFabrik.Create(Random.Range(_gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed),
				_gameConfig.FinishPos.y, this).gameObject;
			}
		}

		for (int i = 0; i < _gameConfig.OpponentsCount; i++)
		{
			Opponents[i].transform.position = _positionController.GetNewPos();
		}

	}

	private void CreatePlayers()
	{
		if (_player == null)
		{
			_player = _playerFabrik.Create(_gameConfig.PlayerSpeed, _gameConfig.FinishPos.y, this).gameObject;
		}
		_player.transform.position = _positionController.GetNewPos();
	}
    
    private void CreateFinish()
    {
        GameObject.Instantiate(_finishPrefab, _gameConfig.FinishPos, Quaternion.identity);
    }
    
    public void Restart()
    {
	    Play();
    }
    
    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}