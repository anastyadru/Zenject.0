using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] private GameConfig _gameConfig;
    public override void InstallBindings()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPositionController>().AsSingle();
        
        Container.BindFactory<float, float, GameController, PlayerController, PlayerController.PlayerFabrik>()
            .FromPrefab(_gameConfig.PlayerPrefab)
            .WithGameObjectName("Player");
        
        Container.BindFactory<float, float, GameController, OpponentController, OpponentController.OpponentFabrik>()
            .FromPrefab(_gameConfig.OpponentPrefab)
            .WithGameObjectName("Enemy");
        
        Container.BindSignal<OpponentWonSignal>();
        Container.BindSignal<PlayerWonSignal>();
        Container.BindSignal<GameStartedSignal>();
        Container.BindSignal<GameFinishedSignal>();
    }
}