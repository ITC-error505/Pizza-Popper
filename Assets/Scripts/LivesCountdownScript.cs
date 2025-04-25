using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LivesCountdownScript : MonoBehaviour
{
    [SerializeField]
    private float imageWidth = 0.13f; // 13 for the width of one heart
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private int lives = 3;

    // private SpriteRenderer sprite;
    private RectTransform image;
    private UnityEngine.Vector3 point;

    public UnityEvent dead;
    public TextMeshProUGUI score;
    public GameoverScreenScript gameover;
    public GameObject stopAsteroids;
    
    private void Awake() {
        // sprite = GetComponent<SpriteRenderer>();
        image = transform as RectTransform;

        AdjustImageWidth();
    }

    private void NumOfLives() {
        if(lives <=  0) { //player is out of lives
            dead?.Invoke();
            gameover.Setup(score.text);
            stopAsteroids.SetActive(false);
        }
        lives = Mathf.Clamp(lives, 0, maxLives);
        AdjustImageWidth(); //this might not be needed
    }

    private void AdjustImageWidth() {
        // sprite.size
        image.sizeDelta = new Vector2(imageWidth * lives, 80);
    }

    public void AddLife(int num) {
        lives += num;
    }

    public void RemoveLife(int num) {
        lives -= num;

        NumOfLives();
    }
    
    // Update is called once per frame
    void Update()
    {
        // NumOfLives();
    }
}
