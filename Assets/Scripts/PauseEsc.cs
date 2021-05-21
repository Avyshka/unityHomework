using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseEsc : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Button _backToGame;
    [SerializeField] Button _lowQuality;
    [SerializeField] Button _mediumQuality;
    [SerializeField] Button _highQuality;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundsSlider;

    [SerializeField] AudioMixer _musicMixer;
    [SerializeField] AudioMixer _soundsMixer;

    private GameSettings _gameSettings = GameSettings.getInstance();

    private void Start()
    {
        _backToGame.onClick.AddListener(UnPause);
        _lowQuality.onClick.AddListener(SetLowQuality);
        _mediumQuality.onClick.AddListener(SetMediumQuality);
        _highQuality.onClick.AddListener(SetHighQuality);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _soundsSlider.onValueChanged.AddListener(SetSoundsVolume);
    }

    private void OnDestroy()
    {
        _backToGame.onClick.RemoveListener(UnPause);
        _lowQuality.onClick.RemoveListener(SetLowQuality);
        _mediumQuality.onClick.RemoveListener(SetMediumQuality);
        _highQuality.onClick.RemoveListener(SetHighQuality);
        _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        _soundsSlider.onValueChanged.RemoveListener(SetSoundsVolume);
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

    private void SetMusicVolume(float value)
    {
        _musicMixer.SetFloat("Volume", value);
    }

    private void SetSoundsVolume(float value)
    {
        _soundsMixer.SetFloat("Volume", value);
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
