using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] TextMeshProUGUI timerDisplay;
    public int score = 0;
    public float timer;
    public float displayTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        displayTimer = Mathf.Round(timer);

        if (scoreDisplay == null) return;
        UpdateUi();
    }

    public static void AddScore()
    {
        instance.score++;
    }

    public static void UpdateUi()
    {
        instance.scoreDisplay.text = "Coins: " + instance.score;
        instance.timerDisplay.text = "Time: " + instance.displayTimer;
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}