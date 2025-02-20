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
            Debug.LogError("Canvas�� �����ϴ�.");
        }

        talkData = new string[]
        {
            "������.....",
            "����.....����....������.....",
            "(����� ������ �� ����.)"
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
