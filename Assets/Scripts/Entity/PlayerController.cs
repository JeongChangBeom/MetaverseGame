using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;


    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }

    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
}
