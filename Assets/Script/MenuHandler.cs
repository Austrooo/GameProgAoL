using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        AudioManager.instance.StopAudio();
        AudioManager.instance.Play("background");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Main Menu");
        AudioManager.instance.StopAudio();
        AudioManager.instance.Play("background");
    }    
}
