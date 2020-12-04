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
    [SerializeField] public bool canGravity = false;




    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;


    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private float timer = 0;
    private bool isFacingRight = true;
    private bool isFacingUp = true;
    public static bool ReverseGravity = false;
    private Animator anim;
    public static bool invulnerable = false;
    bool isDucking = false;
    private bool isLevelEnd = false;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Physics (Update is called once per frame)
    private void FixedUpdate()
    {
        if (isLevelEnd == false)
        {

            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");
            isGrounded = GroundCheck();

            rBody.velocity = new Vector2(hori * speed, rBody.velocity.y);

            // Jump for normal gravity
            if (isGrounded && (Input.GetAxis("Jump") > 0) && ReverseGravity == false)
            {
                rBody.AddForce(new Vector2(0.0f, jumpForce));
                isGrounded = false;
            }
            if (rBody.velocity.y < 0 && ReverseGravity == false)
            {
                rBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
            }
            else if (rBody.velocity.y > 0 && !Input.GetButton("Jump") && ReverseGravity == false)
            {
                rBody.velocity += Vector2.up * Physics2D.gravity.y * (lowfall - 1) * Time.deltaTime;
            }

            // Jump for ReverseGravity
            if (isGrounded && (Input.GetAxis("Jump") > 0) && ReverseGravity == true)
            {
                rBody.AddForce(new Vector2(0.0f, (jumpForce * -1) * 2.5f));
                isGrounded = false;
            }
            if (rBody.velocity.y < 0 && ReverseGravity == true)
            {
                rBody.velocity += (Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime) / 2.5f;
            }
            else if (rBody.velocity.y > 0 && !Input.GetButton("Jump") && ReverseGravity == true)
            {
                rBody.velocity += (Vector2.up * Physics2D.gravity.y * (lowfall - 1) * Time.deltaTime) / 2.5f;
            }


            //flip player
            if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
            {
                Flip();
            }

            if (GravityPage.allowGravity == true)
            {
                canGravity = true;
            }

            //animator
            anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
            anim.SetFloat("yVelocity", rBody.velocity.y);
            anim.SetBool("IsGround", isGrounded);
            anim.SetBool("isDucking", isDucking);

            //ducking (serves no purpose yet, but i loved the sprite) (F I X E D, dont put variables in update loops like that next time)
            if (verti < 0 && hori == 0)
            {
                isDucking = true;
            }
            else
            {
                isDucking = false;
            }

            //FLIP GRAVITY
            if (verti > 0 && isGrounded == true && ReverseGravity == false && canGravity == true)
            {
                rBody.gravityScale *= -1;
                lowfall *= -1;
                fallMulti *= -1;
                YFlip();
                ReverseGravity = true;
                isGrounded = false;
            }
            else if (verti > 0 && isGrounded == true && ReverseGravity == true && canGravity == true)
            {
                rBody.gravityScale *= -1;
                lowfall *= -1;
                fallMulti *= -1;
                YFlip();
                ReverseGravity = false;
                isGrounded = false;
            }

            //if (verti > 0 && isGrounded == true && ReverseGravity == true && canGravity == true)
            //{
            //rBody.gravityScale *= -1;
            //lowfall *= -1;
            //fallMulti *= -1;
            //YFlip();
            //ReverseGravity = false;
            //}
        }
        else
        {
            anim.SetFloat("xVelocity", 0.0f);
            anim.SetFloat("yVelocity", 0.0f);
            anim.SetBool("IsGround", true);
            rBody.velocity = new Vector2(0, rBody.velocity.y);
        }
    }


    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    // Detect when the enemy collides with the player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            WinAndDeathText.IsDeath = true;
            ReverseGravity = false;
        }

        if (other.gameObject.CompareTag("Win"))
        {
            Destroy(gameObject);
            WinAndDeathText.IsWin = true;
            ReverseGravity = false;
        }
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        isFacingRight = !isFacingRight;
    }

    private void YFlip()
    {
        Vector3 temp = transform.localScale;
        temp.y *= -1;
        transform.localScale = temp;
        isFacingUp = !isFacingUp;
    }

    public void LevelEndTrigger()
    {
        isLevelEnd = true;
    }

}