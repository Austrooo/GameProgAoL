using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int hp;

    [SerializeField] private TMP_Text hpText;

    private void Start()
    {
        hp = 100;
    }

    private void Update()
    {
        if (hp == 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        hpText.text = "HP: " + hp;
    }

    public void DecreaseHP(int amount)
    {
        hp -= amount;
    }
}
