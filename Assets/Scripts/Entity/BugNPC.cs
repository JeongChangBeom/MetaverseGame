using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugNPC : BaseInteractiveObjects
{
    UIManager uiManager;
    ChatUI chatUI;

    string[] talkData;
    SpriteRenderer portrait;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            uiManager = canvas.GetComponent<UIManager>();
            chatUI = uiManager.GetComponentInChildren<ChatUI>(true);
        }
        else
        {
            Debug.LogError("Canvas가 없습니다.");
        }

        talkData = new string[]
        {
            "사사사사삭.....:0",
            "사사삭.....사사삭....사사사사삭.....:0",
            "그만 말 걸어:0",
            "????????????:1",
            "(평범한 벌레는 아닌 것 같다.):1"
        };

        portrait = GetComponent<SpriteRenderer>();
    }


    public override void Interactive()
    {
        base.Interactive();
        chatUI.GetData(talkData, portrait.sprite);
        uiManager.ChangeState(UIState.Chat);
    }

    public override void OffKey()
    {
        base.OffKey();
        uiManager.ChangeState(UIState.Game);
    }
}
