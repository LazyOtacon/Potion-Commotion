using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" Variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] public float fallMulti;
    [SerializeField] public float lowfall;




    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;


    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private float timer = 0;
    private bool isFacingRight = true;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Physics (Update is called once per frame)
    private void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        bool isDucking = false;
        isGrounded = GroundCheck();

        rBody.velocity = new Vector2(hori * speed, rBody.velocity.y);

        // Jump
        if(isGrounded && (Input.GetAxis("Jump") > 0))
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }
        if (rBody.velocity.y < 0)
        {
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (lowfall - 1) * Time.deltaTime;
        }

        //flip player
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }



        //animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("IsGround", isGrounded);
        anim.SetBool("isDucking", isDucking);

        //ducking (serves no purpose yet but i loved the sprite) (also broken and does not work and i havent a clue why)
        if (verti < 0 && hori == 0)
        {
            isDucking = true;
        }
        else
        {
            isDucking = false;
        }

    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    // Detect when the enemy collides with the player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        isFacingRight = !isFacingRight;
    }



}