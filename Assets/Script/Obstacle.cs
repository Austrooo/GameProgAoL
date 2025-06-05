using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().ResetPosition();
            GameObject.FindAnyObjectByType<CameraHandler>().SetPriority(1);
            gc.DecreaseHP(20);
        }
    }
}
