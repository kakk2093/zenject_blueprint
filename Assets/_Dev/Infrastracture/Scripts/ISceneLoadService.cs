
using Zenject;

public interface ISceneLoadService
{
    
    void LoadFirstScene(int level);
    void LoadNextScene();
    void RestartScene();
    
}
