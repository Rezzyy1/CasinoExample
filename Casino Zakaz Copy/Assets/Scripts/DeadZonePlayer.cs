using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZonePlayer : MonoBehaviour
{

    [SerializeField] private float delayBeforeReload = 1.2f;
    private ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            Debug.Log("Collision done");
            Invoke("OnPlayerDeath", delayBeforeReload);
        }
    }

    void Start()
    {
        // ����� ������ ScoreManager � ����� � �������� ���������
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
    }

    /*private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    public void OnPlayerDeath()
    {
        // ��������� ���� ����� ������������� �����
        scoreManager.EndGame();

        // ������������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
