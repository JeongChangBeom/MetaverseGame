using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBox : BaseInteractiveObjects
{
    UIManager uiManager;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            uiManager = canvas.GetComponent<UIManager>();
        }
        else
        {
            Debug.LogError("Canvas가 없습니다.");
        }
    }

    //  게임박스에서 상호작용하면 게임박스의 UI가 활성화 됨
    public override void Interactive()
    {
        base.Interactive();
        uiManager.ChangeState(UIState.GameBox);
    }

    //  게임박스에서 떨어지면 게임박스의 UI가 비활성화 되고 다시 게임 UI가 활성화 됨
    public override void OffKey()
    {
        base.OffKey();
        uiManager.ChangeState(UIState.Game);
    }
}
