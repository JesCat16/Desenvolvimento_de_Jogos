using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Move;
    public float speed;
    public float jump;

    public Vector2 collisionGround;
    public float seeGround;
    public LayerMask ground;

    private Animator animator;

    private bool isFasingRight;

    public RawImage background;
    private float react = 0f;

    public float KnockbackForce;
    public float KnockbackTime;
    public float KnockbackCounter;

    public bool knockbackFromRight;
    public static System.Action addCoin;
    // Start is called before the first frame update
    void Start()
    {
        isFasingRight = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        background.uvRect = new Rect(react, 0, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogManager.Instance.isTalking)
        {
            Move = 0f;
            animator.SetBool("isWalking", false);
            return;
        }

        Move = Input.GetAxisRaw("Horizontal");

        if(KnockbackCounter <= 0)
        {
            rb.velocity = new Vector2(Move * speed, rb.velocity.y);
        }
        else
        {
            if (knockbackFromRight)
            {
                rb.velocity = new Vector2(-KnockbackForce, KnockbackForce);
            }
            if (!knockbackFromRight)
            {
                rb.velocity = new Vector2(KnockbackForce, KnockbackForce);
            }
            KnockbackCounter -= Time.deltaTime;
        }


        if(Input.GetButtonDown("Jump") && isInGround())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }

        if (Move != 0)
        {
            animator.SetBool("isWalking", true);
            MoveBack(Move);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        animator.SetBool("isJumping", !isInGround());

        if(!isFasingRight && Move > 0)
        {
            Flip();
        }
        else if(isFasingRight && Move < 0)
        {
            Flip();
        }

    }

    public void Flip()
    {
        isFasingRight = !isFasingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public bool isInGround()
    {
        if (Physics2D.BoxCast(transform.position, collisionGround, 0, -transform.up, seeGround, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * seeGround, collisionGround);
    }

    void MoveBack(float Movement)
    {
        background.uvRect = new Rect(react + Movement/5000, 0, 1, 1);
        react = background.uvRect.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("noGround"))
        {
            animator.SetBool("isDead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            addCoin.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
