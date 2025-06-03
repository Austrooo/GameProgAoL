using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSpriteManager : MonoBehaviour
{
    private SpriteRenderer sr;
    private Character ch;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite jumpingSprite;
    [SerializeField] private Sprite midAirSprite;

    private void Start()
    {
        ch = GetComponent<Character>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = idleSprite;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sr.sprite = jumpingSprite;
        }
        else sr.sprite = idleSprite;
        float facing = Input.GetAxis("Horizontal");
        // If the input is positive and the character is facing left, flip the sprite
        if(ch.isGrounded)
        {
            if (facing > 0)
            {
                Flip(false);
            }
            // If the input is negative and the character is facing right, flip the sprite
            else if (facing < 0)
            {
                Flip(true);
            }
        }
    }

    private void Flip(bool status)
    {
        sr.flipX = status;
    }
}
