using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public float jumpForce;

    bool isGrounded = false;
    public Transform groundChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public Animator animator;

    public EyeScript eyeScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coffee")
        {
            eyeScript.sleepSlider.value -= 37.5f;
            eyeScript.topLids.transform.position = new Vector3(eyeScript.topLids.transform.position.x, eyeScript.topLids.transform.position.y + 1.65f, eyeScript.topLids.transform.position.z);
            eyeScript.bottomLids.transform.position = new Vector3(eyeScript.bottomLids.transform.position.x, eyeScript.bottomLids.transform.position.y - 1.65f, eyeScript.bottomLids.transform.position.z);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Door")
        {
            collision.gameObject.GetComponent<SceneManagerScript>().LoadAScene();
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveSpeed = x * speed;
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("isMoving", true);
        }
        if (rb.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("isMoving", true);
        }
        if(rb.velocity.x == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void GroundCheck()
    {
        Collider2D colliders = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
            animator.speed = 1;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
            animator.speed = 0;
        }
    }
}
