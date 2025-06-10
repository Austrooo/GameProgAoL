using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private int hp;
    [SerializeField] private int coins;

    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text progressText;

    private float startPosition;
    private float endPosition;
    private float currentPosition;

    private void Start()
    {
        hp = 100;
        coins = 0;
        DontDestroyOnLoad(gameObject);

        startPosition = GameObject.FindAnyObjectByType<Character>().transform.position.y;
        endPosition = GameObject.FindAnyObjectByType<Star>().transform.position.y;
        currentPosition = startPosition;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (hp == 0)
        {
            AudioManager.instance.StopAudio();
            AudioManager.instance.Play("lose");
            SceneManager.LoadScene("Game Over");
        }
        currentPosition = GameObject.FindAnyObjectByType<Character>().transform.position.y;
        hpText.text = "HP : " + hp;
        coinText.text = "Coins : " + coins;
        progressText.text = "Progress : " + (CalculateProgress() * 100).ToString("F2") + "%";
    }

    public void DecreaseHP(int amount)
    {
        hp -= amount;
    }

    public void AddCoin()
    {
        coins++;
    }

    public float CalculateProgress()
    {
        float percentage = (currentPosition - startPosition) / (endPosition - startPosition);
        return Mathf.Clamp01(percentage);
    }
}
