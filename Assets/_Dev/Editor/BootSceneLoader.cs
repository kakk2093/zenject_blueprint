using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public static class BootSceneLoader 
{
    
    private const string BOOT_SCENE_PATH = "Assets/_Dev/Scenes/BootScene.unity";
    private const string SAVE_KEY_PREVIUS_SCENE = "PriviusScene";


    static BootSceneLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChange;
    }

    private static void OnPlayModeStateChange(PlayModeStateChange state)
    {
        if(!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                return;

            var pathPrevScene = SceneManager.GetActiveScene().path;
            EditorPrefs.SetString(SAVE_KEY_PREVIUS_SCENE, pathPrevScene);


            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                try
                {
                    EditorSceneManager.OpenScene(BOOT_SCENE_PATH);
                }

                catch
                {
                    Debug.LogError($"Cannot load scene: {BOOT_SCENE_PATH} ");
                    EditorApplication.isPlaying = false;
                }
            }

        }
        if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            try
            {
                var path = EditorPrefs.GetString(SAVE_KEY_PREVIUS_SCENE);
                EditorSceneManager.OpenScene(path);
            }
            catch
            {
                Debug.LogError("Cant load f scene");
            }
        }
    }
}
