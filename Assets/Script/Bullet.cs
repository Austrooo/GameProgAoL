using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().ResetPosition();
        }
        Debug.Log("IS COLLIDING");
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
