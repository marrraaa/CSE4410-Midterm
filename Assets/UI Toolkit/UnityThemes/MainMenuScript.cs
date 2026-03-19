using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _startButton;
    private Button _quitButton;
    private AudioSource _audioSource;

    [SerializeField] private string gameSceneName = "SampleScene";
    [SerializeField] private float clickDelay = 0.15f;

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();
        _audioSource = GetComponent<AudioSource>();

        var root = _document.rootVisualElement;

        _startButton = root.Q<Button>("StartGameButton");
        _quitButton = root.Q<Button>("QuitButton");

        if (_startButton != null)
            _startButton.clicked += OnStartClicked;

        if (_quitButton != null)
            _quitButton.clicked += OnQuitClicked;
    }

    private void OnDisable()
    {
        if (_startButton != null)
            _startButton.clicked -= OnStartClicked;

        if (_quitButton != null)
            _quitButton.clicked -= OnQuitClicked;
    }

    private void OnStartClicked()
    {
        StartCoroutine(PlaySoundAndLoadScene());
    }

    private void OnQuitClicked()
    {
        StartCoroutine(PlaySoundAndQuit());
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        PlayClickSound();
        yield return new WaitForSecondsRealtime(clickDelay);
        SceneManager.LoadScene(gameSceneName);
    }

    private IEnumerator PlaySoundAndQuit()
    {
        PlayClickSound();
        yield return new WaitForSecondsRealtime(clickDelay);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlayClickSound()
    {
        if (_audioSource != null && _audioSource.clip != null)
        {
            _audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
        }
    }
}