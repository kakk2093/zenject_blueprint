using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoadService : MonoBehaviour, ISceneLoadService
{
    private ISaveValueService _saveValueService;

    [Inject]
    private void Construct(ISaveValueService saveValueService)
    {
        _saveValueService = saveValueService;
    }

    private void Start()
    {
        LoadFirstScene(_saveValueService.LevelNumber);
    }

    public void LoadFirstScene(int level)
    {
        StartCoroutine(LoadFirstSceneCorutine(level));
    }

    public IEnumerator LoadFirstSceneCorutine(int value)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(value);
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadNextSceneCorutine());
    }

    private IEnumerator LoadNextSceneCorutine()
    {
        OnFinishLevel();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_saveValueService.LevelNumber);
    }

    private void OnFinishLevel()
    {
        _saveValueService.LevelNumber++;
        _saveValueService.TrueLevelNumber++;

        if (_saveValueService.LevelNumber > 12)// idnex of last scene 12 
            _saveValueService.LevelNumber = 4;

        // int randomLevel = UnityEngine.Random.Range(4,20);
        // SceneManager.LoadScene(randomLevel);
    }

    public void RestartScene()
    {
        StartCoroutine(RestartLevelCorutine());
    }

    public IEnumerator RestartLevelCorutine()
    {
        float delay = 0.5f;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
