using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Character character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            character.rb.sharedMaterial = character.notBouncy;
            character.isGrounded = true;
            //character.rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            character.rb.sharedMaterial = character.notBouncy;
            character.isGrounded = true;
            //character.rb.velocity = new Vector2(0, 0);
        }
    }
}
