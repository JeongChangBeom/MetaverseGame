using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBox : BaseInteractiveObjects
{
    UIManager uiManager;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if(canvas != null)
        {
            uiManager = canvas.GetComponent<UIManager>();
        }
        else
        {
            Debug.LogError("Canvas가 없습니다.");
        }
    }

    public override void Interactive()
    {
        base.Interactive();

        uiManager.ChangeState(UIState.GameBox);
    }

    public override void OffKey()
    {
        base.OffKey();
        uiManager.ChangeState(UIState.Game);
    }
}
