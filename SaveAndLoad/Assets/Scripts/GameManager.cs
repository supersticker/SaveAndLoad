using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] int score = 0;


    private void Awake()
    {
        instance = this;
    }

    public static void AddScore()
    {
        instance.score++;
        instance.scoreDisplay.text = instance.score.ToString();
    }
}