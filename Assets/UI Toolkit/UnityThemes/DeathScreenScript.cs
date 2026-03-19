using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _container;

    private Button _restartButton;
    private Button _mainMenuButton;
    private Button _quitButton;

    private AudioSource _audioSource;

    [SerializeField] private string gameSceneName = "SampleScene";
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private float clickDelay = 0.15f;

    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();
        _audioSource = GetComponent<AudioSource>();

        var root = _document.rootVisualElement;

        _container = root.Q<VisualElement>("Container");

        _restartButton = root.Q<Button>("RestartButton");
        _mainMenuButton = root.Q<Button>("MainMenuButton");
        _quitButton = root.Q<Button>("QuitButton");

        if (_restartButton != null)
            _restartButton.clicked += OnRestartClicked;

        if (_mainMenuButton != null)
            _mainMenuButton.clicked += OnMainMenuClicked;

        if (_quitButton != null)
            _quitButton.clicked += OnQuitClicked;

        // Hide initially
        if (_container != null)
            _container.style.display = DisplayStyle.None;
    }

    private void OnDisable()
    {
        if (_restartButton != null)
            _restartButton.clicked -= OnRestartClicked;

        if (_mainMenuButton != null)
            _mainMenuButton.clicked -= OnMainMenuClicked;

        if (_quitButton != null)
            _quitButton.clicked -= OnQuitClicked;
    }


    // REMOVE WHEN ADDED DEATH MECHANIC // // REMOVE WHEN ADDED DEATH MECHANIC // 
    private void Update()
    {
        // Press K to show death screen
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowDeathScreen();
        }

        // Optional: press H to hide it again
        if (Input.GetKeyDown(KeyCode.H))
        {
            HideDeathScreen();
        }
    }

    // --- BUTTON ACTIONS ---

    private void OnRestartClicked()
    {
        StartCoroutine(PlaySoundAndRestart());
    }

    private void OnMainMenuClicked()
    {
        StartCoroutine(PlaySoundAndLoadMenu());
    }

    private void OnQuitClicked()
    {
        StartCoroutine(PlaySoundAndQuit());
    }

    // --- COROUTINES ---

    private IEnumerator PlaySoundAndRestart()
    {
        PlayClickSound();
        yield return new WaitForSecondsRealtime(clickDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    private IEnumerator PlaySoundAndLoadMenu()
    {
        PlayClickSound();
        yield return new WaitForSecondsRealtime(clickDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
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

    // --- SOUND ---

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

    // --- SHOW / HIDE ---

    public void ShowDeathScreen()
    {
        if (_container != null)
            _container.style.display = DisplayStyle.Flex;

        Time.timeScale = 0f;
    }

    public void HideDeathScreen()
    {
        if (_container != null)
            _container.style.display = DisplayStyle.None;

        Time.timeScale = 1f;
    }
}