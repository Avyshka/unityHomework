using UnityEngine;

public class GameSettings
{
    public bool paused = false;

    private static GameSettings _instance;

    public static GameSettings getInstance()
    {
        if (_instance == null)
        {
            _instance = new GameSettings();
        }
        return _instance;
    }
}
