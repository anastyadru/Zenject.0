using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    
    [Inject] private GameController _gameController;
    [Inject] private GameStartedSignal _gameStartedSignal;
    [Inject] private GameFinishedSignal _gameFinishedSignal;

    private void Start()
    {
        _gameStartedSignal.Listen(GameStarted);
        _gameFinishedSignal.Listen(GameFinished);
    }
    
    private void OnApplicationQuit()
    {
        _gameStartedSignal.Unlisten(GameStarted);
        _gameFinishedSignal.Unlisten(GameFinished);
    }

    private void GameStarted()
    {
        HideMenuPanel();
        ShowGamePanel();
    }
    
    private void GameFinished()
    {
        ShowMenuPanel();
        HideGamePanel();
    }

    void OnValidate()
    {
        _menuPanel = transform.Find("pnl_MainMenu").gameObject;
        _gamePanel = transform.Find("pnl_GamePanel").gameObject;
    }

    public void ShowMenuPanel()
    {
        _menuPanel.SetActive(true);
    }
    public void HideMenuPanel()
    {
        _menuPanel.SetActive(false);
    }
    
    public void ShowGamePanel()
    {
        _gamePanel.SetActive(true);
    }
    public void HideGamePanel()
    {
        _gamePanel.SetActive(false);
    }

    public void OnExitBtnClicked()
    {
        _gameController.Exit();
    }
    public void OnPlayBtnClicked()
    {
        _gameController.Play();
    }
    public void OnRestartBtnClicked()
    {
        _gameController.Restart();
    }
}