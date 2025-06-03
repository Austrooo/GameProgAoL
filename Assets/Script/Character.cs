using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private GameObject forceIndicator;
    public PhysicsMaterial2D bouncy;
    public PhysicsMaterial2D notBouncy;

    [SerializeField] private Vector3 defaultPosition;

    private float moveInput;
    private float speed;
    public bool isGrounded;

    private float jumpForce;
    private float minForce;
    private float maxForce;

    private bool chargingJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bouncy = new PhysicsMaterial2D("Bouncy");
        notBouncy = new PhysicsMaterial2D("NotBouncy");
        bouncy.bounciness = 1f;
        bouncy.friction = 0f;
        notBouncy.bounciness = 0f;
        notBouncy.friction = 0f;

        defaultPosition = transform.position;

        speed = 5f;
        minForce = 2f;
        jumpForce = 0f;
        maxForce = 10f;

        chargingJump = true;
        forceIndicator.SetActive(false);
    }
    private void Update()
    {
        //Debug.Log(rb.sharedMaterial.name);
        moveInput = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            rb.sharedMaterial = notBouncy;
            rb.velocity = Vector2.zero;
            if (Input.GetButton("Jump"))
            {
                Debug.Log("still holding jump");
                forceIndicator.SetActive(true);
                if (chargingJump)
                {
                    if (jumpForce < maxForce)
                    {
                        jumpForce += Time.deltaTime * 10f;
                        UpdateForceBar();
                    }
                    else
                    {
                        chargingJump = false;
                    }
                }
                else
                {
                    if (jumpForce > minForce)
                    {
                        jumpForce -= Time.deltaTime * 10f;
                        UpdateForceBar();
                    }
                    else
                    {
                        chargingJump = true;
                    }
                }
            }
            else
            {
                forceIndicator.SetActive(false);
                if (jumpForce > 0)
                {
                    //AudioManager.instance.Play("jump");
                    jumpForce += minForce;
                    rb.velocity = new Vector2(moveInput * jumpForce / 10f * speed, jumpForce);
                    jumpForce = 0;
                    isGrounded = false;
                    rb.sharedMaterial = bouncy; 
                }
            }
        }
    }

    private void UpdateForceBar()
    {
        float scalePercent = jumpForce / maxForce;
        float height = scalePercent;

        forceIndicator.transform.localScale = new Vector3(forceIndicator.transform.localScale.x, height, forceIndicator.transform.localScale.z);
        Vector3 newPosition = forceIndicator.transform.position;
        newPosition.y = transform.position.y + (height / 2f);
        forceIndicator.transform.position = newPosition;
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
    }
}
