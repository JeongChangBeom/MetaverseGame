using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rb;

    [SerializeField] private SpriteRenderer chracterRenderer;

    //  플레이어가 바라보고 있는 방향
    protected Vector2 lookDirection = Vector2.down;
    public Vector2 LookDirection { get => lookDirection; }

    //  플레이어의 진행 방향
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; }

    //  플레이어의 정보를 저장
    protected PlayerInfo playerInfo;

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {
        playerInfo = PlayerInfo.instance;
    }

    protected virtual void Update()
    {
        animationHandler.Idle(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    //  입력받은 방향에 따라 플레이어를 이동시키는 함수
    private void Movement(Vector2 direction)
    {
        direction *= playerInfo.PlayerSpeed;

        rb.velocity = direction;
        animationHandler.Move(direction);

        if (direction.x > 0 || lookDirection.x > 0)
        {
            chracterRenderer.flipX = true;
        }
        else
        {
            chracterRenderer.flipX = false;
        }

        if (direction.magnitude > 0)
        {
            lookDirection = direction / playerInfo.PlayerSpeed;
        }
    }
}
