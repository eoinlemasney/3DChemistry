
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    // Checks to see if the game is paused
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
        Debug.Log("PAUSING");
        pauseMenuUI.SetActive(true);
        //Freezes the game
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        //Set normal game speed
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }
}
