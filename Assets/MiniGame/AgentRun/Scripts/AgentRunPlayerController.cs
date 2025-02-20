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

        //  �����̽� �ٸ� ������ ���� (2�� ���� ����)
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
        //  ĳ���Ͱ� ����ؼ� ���������� �̵���
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

   
    private void Die()
    {
        rb.velocity = Vector2.zero;
        isDie = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //  ĳ���Ͱ� ������ ������ ���� Ƚ�� �ʱ�ȭ (�ٽ� ��������)
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

        //  ĳ���Ͱ� ��ֹ��� ��ų� �������� �� GameOver
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
