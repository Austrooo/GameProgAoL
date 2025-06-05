using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.StopAudio();
            AudioManager.instance.Play("win");
            SceneManager.LoadScene("Win");
        }
    }
}
