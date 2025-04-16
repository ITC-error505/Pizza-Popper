using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    public void PauseButton() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
