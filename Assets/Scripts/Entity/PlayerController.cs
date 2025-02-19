using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.ReorderableList;

public class PlayerController : BaseController
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RayInteractive();
    }
    private void RayInteractive()
    {
        float distance = 2f;

        RaycastHit2D hit = Physics2D.Raycast(rb.position, lookDirection, distance, LayerMask.GetMask("Interactive"));

        Debug.DrawRay(rb.position, lookDirection * distance, new Color(1, 0, 0));

        if (hit.collider != null)
        {
            hit.collider.GetComponent<BaseInteractiveObjects>().OnKey();

            if (Input.GetKey(KeyCode.E))
            {
                hit.collider.GetComponent<BaseInteractiveObjects>().Interactive();
            }
        }
    }

    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
}
