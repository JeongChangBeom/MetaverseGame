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

    protected Vector2 lookDirection = Vector2.down;
    public Vector2 LookDirection { get => lookDirection; }

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; }

    protected PlayerInfo playerInfo;
    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInfo = PlayerInfo.instance;
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        animationHandler.Idle(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    //  입력받은 방향에 따라 이동시키는 함수
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
