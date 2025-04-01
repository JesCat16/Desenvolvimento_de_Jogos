using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject pontoA;
    public GameObject pontoB;
    private Rigidbody2D rb;
    private Transform pontoAtual;
    private Animator animator;
    private float speed = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         pontoAtual = pontoB.transform;
         animator = GetComponent<Animator>();
         HitCheck.hit += killed;
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ponto = pontoAtual.position - transform.position;
        if(pontoAtual == pontoB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, pontoAtual.position) < 0.3f && pontoAtual == pontoB.transform)
        {
            Flip();
            pontoAtual = pontoA.transform;
        }
        if (Vector2.Distance(transform.position, pontoAtual.position) < 0.3f && pontoAtual == pontoA.transform)
        {
            Flip();
            pontoAtual = pontoB.transform;
        }
    }

    public void killed()
    {
        animator.SetBool("isDead", true);
    }

}
