using UnityEngine;
using UnityEngine.UI;

public class PauseEsc : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Button _backToGame;
    [SerializeField] Button _lowQuality;
    [SerializeField] Button _mediumQuality;
    [SerializeField] Button _highQuality;

    private GameSettings _gameSettings = GameSettings.getInstance();

    private void Start()
    {
        _backToGame.onClick.AddListener(UnPause);
        _lowQuality.onClick.AddListener(SetLowQuality);
        _mediumQuality.onClick.AddListener(SetMediumQuality);
        _highQuality.onClick.AddListener(SetHighQuality);
    }

    private void OnDestroy()
    {
        _backToGame.onClick.RemoveListener(UnPause);
        _lowQuality.onClick.RemoveListener(SetLowQuality);
        _mediumQuality.onClick.RemoveListener(SetMediumQuality);
        _highQuality.onClick.RemoveListener(SetHighQuality);
    }

    private void SetLowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }

    private void SetMediumQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

    private void SetHighQuality()
    {
        QualitySettings.SetQualityLevel(5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameSettings.paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
        _gameSettings.paused = true;
        _panel.SetActive(_gameSettings.paused);
    }

    private void UnPause()
    {
        Time.timeScale = 1;
        _gameSettings.paused = false;
        _panel.SetActive(_gameSettings.paused);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
