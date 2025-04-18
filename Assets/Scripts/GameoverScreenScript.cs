using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScreenScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject pauseButton;
    public void Setup(string score) {
        gameObject.SetActive(true);
        pauseButton.SetActive(false);
        
        scoreText.text = "Score: " + score.ToString();
        
        Time.timeScale = 0f;
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }
}
