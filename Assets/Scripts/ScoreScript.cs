using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
