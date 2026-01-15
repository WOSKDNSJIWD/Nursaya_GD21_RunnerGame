using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText; // —сылка на текстовый элемент UI
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update is called once per frame
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
