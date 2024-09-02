using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ������ Text ��� ����������� ������� �����
    public Text totalScoreText; // ������ Text ��� ����������� ������ ���������� ����� 
    private float topScore = 0f; // ���������� ��� ������������ ������������� �������� Y
    private Rigidbody2D playerRb; // ������ �� Rigidbody2D ������
    public GameObject player; // ������ �� ������ ���������

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();

        // ����������� ������ ���������� ����� ��� ������ ����
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        totalScoreText.text = "Total Score: " + totalScore.ToString();
    }

    void Update()
    {
        // ��������� ������� ���� � ����������� �� ������ ���������
        if (playerRb.velocity.y > 0 && player.transform.position.y > topScore)
        {
            topScore = player.transform.position.y;
        }

        // ��������� ����� ������� ����� �� ������
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    public void EndGame()
    {
        // �������� ������ ���������� �����
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);

        // ���������� ����� �� ������� ������ � ������ ����������
        totalScore += Mathf.RoundToInt(topScore); // ����������� ������� ���� � ����� ����� � ��������� � ������ �����

        // ���������� ������������ ������ ���������� �����
        PlayerPrefs.SetInt("TotalScore", totalScore);

        // ���������� ������ ���������� ����� �� UI
        totalScoreText.text = "Total Score: " + totalScore.ToString();

        // ��������� ����� ������� ������
        topScore = 0;

        // ���������� ����������
        PlayerPrefs.Save();
    }

    /*public void OnPlayerDeath()
    {
        // ��������� ���� ����� ������������� �����
        EndGame();

        // ������������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}

