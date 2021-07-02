using UnityEngine.SceneManagement;
using UnityEngine;

/*
Allows the player to respawn and go to the menu
Written by Daniel Kasprzyk
*/

public class DeathScreen : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Respawn()
    {
        gameManager.PlayerRespawn();
        gameManager.EnemyRespawn();
    }

    public void RestartLevel()
    {
        gameManager.PlayerRespawn();
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        print("Quitting game...");
        Application.Quit();
    }
}
