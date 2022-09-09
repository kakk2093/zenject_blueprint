using System;

public interface IGamePlayService
{

    public event Action GameOverEvent;
    public event Action GameStartEvent;
    public event Action WinPopupShowEvent;
    public event Action MiniGameEndEvent;
    public event Action FinisherStartEvent;
    public event Action SceneLoadEvent;

    void GameStart();
    void GameOver();
    void WinPopupShow();
    void MiniGameEnd();
    void FinisherStart();
    void SceneLoad();
}
