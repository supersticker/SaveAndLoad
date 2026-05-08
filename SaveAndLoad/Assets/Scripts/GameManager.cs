using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public static void AddScore()
    {
        instance.score++;
        UpdateUi();
    }

    public static void UpdateUi()
    {
        instance.scoreDisplay.text = instance.score.ToString();
    }
}