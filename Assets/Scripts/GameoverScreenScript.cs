using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScreenScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public void Setup(string score) {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }
}
