using Zenject;
using NUnit.Framework;

[TestFixture]
public class UntitledUnitTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void SetUp()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPositionController>().AsSingle();

        Container.BindFactory<float, float, GameController, PlayerController, PlayerController.PlayerFabrik>().FromGameObject();

        Container.BindFactory<float, float, GameController, OpponentController, OpponentController.OpponentFabrik>().FromGameObject();

        Container.BindSignal<OpponentWonSignal>();
        Container.BindSignal<PlayerWonSignal>();
        
        Container.Bind<GameConfig>().FromMock();
        Container.Bind<GameController>().FromGameObject();
        Container.Bind<UIController>().FromGameObject();
        Container.Bind<GameObject>().FromGameObject();

        Container.BindSignal<OpponentWonSignal>();
        Container.BindSignal<PlayerWonSignal>();
        Container.BindSignal<GameStartedSignal>();
        Container.BindSignal<GameFinishedSignal>();
        
        Container.Inject(this);
    }
    
    [Inject] private GameController _gameController;
    [Inject] private GameConfig _gameConfig;
    
    [Test]
    public void IsPlayerNotNull_Test()
    {
        _gameController.Play();
        Assert.IsNotNull(_gameController.Player);
    }
    
    [Test]
    public void OpponentsCreate_Test()
    {
        _config.OpponentsCount = 25;
        _gameController.Play();
        Assert.AreEqual(_gameController.Opponents.Length, _config.OpponentsCount);
    }
}