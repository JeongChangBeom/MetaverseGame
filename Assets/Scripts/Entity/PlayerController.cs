using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.ReorderableList;

public class PlayerController : BaseController
{
    //  플레이어가 생성될 때 PlayerInfo에 저장되어 있는 플레이어 정보를 가져옴
    protected override void Start()
    {
        base.Start();

        transform.position = PlayerInfo.instance.PlayerPosition;
        EquipItem(PlayerInfo.instance.PlayerItem);
        ApplyColor(PlayerInfo.instance.PlayerColor);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RayInteractive();
    }

    //  플레이어가 바라보는 방향으로 레이캐스트를 쏘고, 레이캐스트가 상호작용 가능한 객체와 충돌했을 때 "E"키를 누르면 상호작용 가능
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

    //  플레이어가 장비를 장착하는 함수
    public void EquipItem(Item currentItem)
    {
        SpriteRenderer equipItem = GameObject.Find("Player/Item").GetComponent<SpriteRenderer>();

        switch (currentItem)
        {
            case Item.Sword:
                equipItem.sprite = Resources.Load<Sprite>("Sword");
                break;
            case Item.Bow:
                equipItem.sprite = Resources.Load<Sprite>("Bow");
                break;
            case Item.Hammer:
                equipItem.sprite = Resources.Load<Sprite>("Hammer");
                break;
            default:
                break;
        }
    }

    //  플레이어의 색을 변경하는 함수
    public void ApplyColor(Color currentColor)
    {
        SpriteRenderer player = GameObject.Find("Player/MainSprite").GetComponent<SpriteRenderer>();
        player.color = currentColor;

        PlayerInfo.instance.PlayerColor = currentColor;
    }

    //  Unity의 Input Sytem을 활용하여 키입력을 받아 움직이는 방향을 정해주는 함수
    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
}
