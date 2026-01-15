using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Панель для отображения при окончании игры
    [SerializeField] private TextMeshProUGUI scoreText; // Текст для текущего счёта
    [SerializeField] private TextMeshProUGUI livesText; // Текст для жизней
    [SerializeField] private GameObject gameOverText; // Текст "Game Over"
    [SerializeField] PlayerController playerController; // Ссылка на PlayerController для проверки состояния игры
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject restartButton; // Кнопка перезапуска игры

    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
        gameOverText.SetActive(false); // Скрыть текст "Game Over" в начале игры
        gameOverPanel.SetActive(false); // Скрыть панель окончания игры в начале
        restartButton.SetActive(false); 
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives; // Обновление текста жизней
    }
        



    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void ShowGameOverUI()
    {
        finalScoreText.text = " " + score;
        gameOverPanel.SetActive(true); // Показать панель окончания игры
        restartButton.gameObject.SetActive(true); // Показать кнопку перезапуска
        finalScoreText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагрузка текущей сцены
    }


}
