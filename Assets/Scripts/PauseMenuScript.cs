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
    // [SerializeField]
    public AudioMuffleScript audioMuffle;

    public void PauseButton() {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        audioMuffle.OnGamePause();
    }
    public void ResumeButton() {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        audioMuffle.OnGameUnpause();
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        audioMuffle.OnGameUnpause();
    }
}
