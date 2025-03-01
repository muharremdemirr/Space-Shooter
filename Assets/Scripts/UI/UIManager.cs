using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject pausePanel;
    bool isPause;

    public GameObject GameOverPanel;
    public GameObject finishPanel;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdatePause();
        }
    }

    private void UpdatePause()
    {
        isPause = !isPause;

        if (isPause)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);

        }
    }

    public void PauseButton()
    {
        SoundManager.instance.MouseClickSound();
        if (!isPause)
        {
            UpdatePause();
        }
    }

    public void ResumeButton()
    {
        SoundManager.instance.MouseClickSound();
        if (isPause)
        {
            UpdatePause();
        }
    }
    public void ExitButton()
    {
        SoundManager.instance.MouseClickSound();
        Application.Quit();
    }


    public void OpenGameOverPanel()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SoundManager.instance.MouseClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void OpenFinishPanel()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnMainMenu()
    {
        SoundManager.instance.MouseClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
