using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int numberOfEnemies;
    public GameObject gameOverMenu;
    public GameObject winLevelMenu;
    public GameObject survivalTimer;

    public GameObject[] spawners;

    private int enemiesKilled;

    public float currentTime = 0;
    public float startingTime = 60f;
    public bool timeIsRunning = false;


    public TMP_Text timeText;
    public TMP_Text message;

    void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) == 4)
        {
            timeIsRunning = true;
            currentTime = startingTime;
            survivalTimer.SetActive(true);
            foreach (GameObject spawner in spawners) spawner.SetActive(true);
        }
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (currentTime <= 0)
            {
                timeIsRunning = false;
                foreach (GameObject spawner in spawners) spawner.SetActive(false);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies) {
                    var enemyHealthController = enemy.GetComponent<HealthController>();
                    enemyHealthController.TakeDamage(1000);
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                var playerHealthController = player.GetComponent<HealthController>();
                if (playerHealthController.CurrentHealth() > 0) {
                    SceneManager.LoadScene("Final");
                }
            }
            else
            {
                currentTime -= 1 * Time.deltaTime;
                timeText.text = currentTime.ToString("00");
            }
        }
    }

    public void HasWonLevel(Component sender, object data)
    {
        if (data is bool)
        {
            enemiesKilled += 1;
            if (enemiesKilled == numberOfEnemies) winLevelMenu.SetActive(true);
            else winLevelMenu.SetActive(false);
        }
    }

    public void EnableGameOverMenu(Component sender, object data)
    {
        if (data is bool value)
        {
            gameOverMenu.SetActive(value);
            if (timeIsRunning) timeIsRunning = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (levelIndex < 5)SceneManager.LoadScene(levelIndex + 1);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
