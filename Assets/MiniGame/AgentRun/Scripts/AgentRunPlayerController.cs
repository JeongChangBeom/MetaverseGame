using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgentRunPlayerController : MonoBehaviour
{
    public float speed = 10f;

    private static readonly int IsGround = Animator.StringToHash("IsGround");
    private static readonly int IsDie = Animator.StringToHash("IsDie");

    public float jumpForce = 1000f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDie = false;
    public bool IsDead { get => isDie; }

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (isDie)
        {
            return;
        }

        //  스페이스 바를 누르면 점프 (2단 점프 가능)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        anim.SetBool(IsGround, isGrounded);
    }

    private void FixedUpdate()
    {
        if (isDie)
        {
            return;
        }
        //  캐릭터가 계속해서 오른쪽으로 이동함
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

   
    private void Die()
    {
        rb.velocity = Vector2.zero;
        isDie = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //  캐릭터가 발판을 밟으면 점프 횟수 초기화 (다시 점프가능)
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

        //  캐릭터가 장애물을 밟거나 떨어졌을 때 GameOver
        if (collision.gameObject.CompareTag("Dead"))
        {
            Die();
            AgentRunManager.Instance.GameOver();
            anim.SetTrigger(IsDie);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
