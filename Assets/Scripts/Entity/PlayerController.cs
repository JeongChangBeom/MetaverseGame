using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.ReorderableList;

public class PlayerController : BaseController
{
    //  �÷��̾ ������ �� PlayerInfo�� ����Ǿ� �ִ� �÷��̾� ������ ������
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

    //  �÷��̾ �ٶ󺸴� �������� ����ĳ��Ʈ�� ���, ����ĳ��Ʈ�� ��ȣ�ۿ� ������ ��ü�� �浹���� �� "E"Ű�� ������ ��ȣ�ۿ� ����
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

    //  �÷��̾ ��� �����ϴ� �Լ�
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

    //  �÷��̾��� ���� �����ϴ� �Լ�
    public void ApplyColor(Color currentColor)
    {
        SpriteRenderer player = GameObject.Find("Player/MainSprite").GetComponent<SpriteRenderer>();
        player.color = currentColor;

        PlayerInfo.instance.PlayerColor = currentColor;
    }

    //  Unity�� Input Sytem�� Ȱ���Ͽ� Ű�Է��� �޾� �����̴� ������ �����ִ� �Լ�
    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
}
