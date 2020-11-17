using System;
using UnityEngine.SceneManagement;

public static class SceneLoader {
    public enum Scene {
        Game,
        LoadGame,
        Lobby,
        MainMenu,
        Options,
        PlayMenu,
        Startup,
        CreateGame,
        Score
    }

    private static Action onLoaderCallback;

    public static void LoadWithLoader(Scene scene) {
        onLoaderCallback = () => SceneManager.LoadScene(scene.ToString());
        SceneManager.LoadScene(Scene.LoadGame.ToString());
    }

    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
    
    public static void LoaderCallback() {
        if (onLoaderCallback == null) return;
        onLoaderCallback();
        onLoaderCallback = null;
    }
}