using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : BaseInteractiveObjects
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

    //  리더보드에서 상호작용하면 리더보드의 UI가 활성화 됨
    public override void Interactive()
    {
        base.Interactive();
        uiManager.ChangeState(UIState.Leaderboard);
    }

    // 리더보드에서 떨어지면 리더보드의 UI가 비활성화 되고 다시 게임 UI가 활성화 됨
    public override void OffKey()
    {
        base.OffKey();
        uiManager.ChangeState(UIState.Game);
    }
}
