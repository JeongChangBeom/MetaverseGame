using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.ReorderableList;

public class PlayerController : BaseController
{
    SpriteRenderer playerSR;
    SpriteRenderer vehicleSR;

    //  �÷��̾ ������ �� PlayerInfo�� ����Ǿ� �ִ� �÷��̾� ������ ������
    protected override void Start()
    {
        base.Start();
        playerSR = GameObject.Find("Player/MainSprite").GetComponent<SpriteRenderer>();
        vehicleSR = GameObject.Find("Player/Vehicle").GetComponent<SpriteRenderer>();

        transform.position = PlayerInfo.instance.PlayerPosition;
        EquipItem(PlayerInfo.instance.PlayerItem);
        ApplyColor(PlayerInfo.instance.PlayerColor);
        RideVehicle(PlayerInfo.instance.PlayerVehicle);
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

    //  �÷��̾ Ż���� Ÿ��
    public void RideVehicle(Vehicle currentVehicle)
    {
        switch (currentVehicle)
        {
            case Vehicle.Null:
                playerInfo.PlayerSpeed = 10f;
                playerSR.enabled = true;
                vehicleSR.enabled = false;
                break;
            case Vehicle.RedCar:
                playerInfo.PlayerSpeed = 15f;
                playerSR.enabled = false;
                vehicleSR.enabled = true;
                vehicleSR.sprite = Resources.Load<Sprite>("RedCar");
                break;
            case Vehicle.BlueCar:
                playerInfo.PlayerSpeed = 20f;
                playerSR.enabled = false;
                vehicleSR.enabled = true;
                vehicleSR.sprite = Resources.Load<Sprite>("BlueCar");
                break;
            default:
                break;
        }
    }

    //  Unity�� Input Sytem�� Ȱ���Ͽ� Ű�Է��� �޾� �����̴� ������ �����ִ� �Լ�
    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
}
