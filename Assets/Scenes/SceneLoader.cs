using System;
using UnityEngine.SceneManagement;

// Loads scenes
public static class SceneLoader {
    public enum Scene {
        Game,
        LoadGame,
        Lobby,
        MainMenu,
        Friendlist,
        PlayMenu,
        Startup,
        CreateGame,
        Score,
        Statistics
    }

    private static Action onLoaderCallback;

    // Loads the given scene and shows the loader scene
    public static void LoadWithLoader(Scene scene) {
        onLoaderCallback = () => SceneManager.LoadScene(scene.ToString());
        SceneManager.LoadScene(Scene.LoadGame.ToString());
    }

    // Load the given scene
    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
    
    // Calls the callback method
    public static void LoaderCallback() {
        if (onLoaderCallback == null) return;
        onLoaderCallback();
        onLoaderCallback = null;
    }
}