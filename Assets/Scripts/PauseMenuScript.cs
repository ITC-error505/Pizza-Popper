using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject pauseButton;

    public void PauseButton() {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
