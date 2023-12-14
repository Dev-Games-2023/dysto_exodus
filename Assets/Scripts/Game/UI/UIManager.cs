using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int numberOfEnemies;
    public GameObject gameOverMenu;
    public GameObject winLevelMenu;

    private int enemiesKilled;

    public void HasWonLevel(Component sender, object data)
    {
        if (data is bool) {
            enemiesKilled += 1;
            if (enemiesKilled == numberOfEnemies) {
                Debug.Log("Atingiu objetivo!");
                winLevelMenu.SetActive(true);
            } else {
                winLevelMenu.SetActive(false);
            }
        }
    }

    public void EnableGameOverMenu(Component sender, object data)
    {
        if (data is bool value)
        {
            gameOverMenu.SetActive(value);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (levelIndex < 4){
            SceneManager.LoadScene(levelIndex + 1);
        }
    }

    public void GoToMainMenu()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
