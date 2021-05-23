
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string helpUrl = "https://www.theconicalflask.ie/j-c-science/chemistry";
    public void PlayGame()
    {
        //Loads the second scene in the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void OpenLink() {
        Application.OpenURL(helpUrl);
    }
}
