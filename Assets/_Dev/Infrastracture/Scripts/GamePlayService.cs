using System;
using UnityEngine;

public class GamePlayService : MonoBehaviour, IGamePlayService
{
    public event Action GameOverEvent;
    public event Action GameStartEvent;
    public event Action WinPopupShowEvent;
    public event Action MiniGameEndEvent;
    public event Action FinisherStartEvent;
    public event Action SceneLoadEvent;

    public void GameStart()
    {
        GameStartEvent?.Invoke();
    }

    public void GameOver()
    {
        GameOverEvent?.Invoke();
    }

    public void WinPopupShow()
    {
        WinPopupShowEvent?.Invoke();
    }

    public void MiniGameEnd()
    {
        MiniGameEndEvent?.Invoke();
    }

    public void FinisherStart()
    {
        FinisherStartEvent?.Invoke();
    }

    public void SceneLoad()
    {
        SceneLoadEvent?.Invoke();
    }
}
