using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Объект Text для отображения текущих очков
    public Text totalScoreText; // Объект Text для отображения общего количества очков 
    private float topScore = 0f; // Переменная для отслеживания максимального значения Y
    private Rigidbody2D playerRb; // Ссылка на Rigidbody2D игрока
    public GameObject player; // Ссылка на объект персонажа

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();

        // Отображение общего количества очков при старте игры
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        totalScoreText.text = "Total Score: " + totalScore.ToString();
    }

    void Update()
    {
        // Обновляем топовый счет в зависимости от высоты персонажа
        if (playerRb.velocity.y > 0 && player.transform.position.y > topScore)
        {
            topScore = player.transform.position.y;
        }

        // Обновляем текст текущих очков на экране
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    public void EndGame()
    {
        // Загрузка общего количества очков
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);

        // Добавление очков за текущую сессию к общему количеству
        totalScore += Mathf.RoundToInt(topScore); // Преобразуем топовый счет в целое число и добавляем к общему счету

        // Сохранение обновленного общего количества очков
        PlayerPrefs.SetInt("TotalScore", totalScore);

        // Обновление общего количества очков на UI
        totalScoreText.text = "Total Score: " + totalScore.ToString();

        // Обнуление очков текущей сессии
        topScore = 0;

        // Применение сохранений
        PlayerPrefs.Save();
    }

    /*public void OnPlayerDeath()
    {
        // Сохраняем очки перед перезагрузкой сцены
        EndGame();

        // Перезагружаем сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}

