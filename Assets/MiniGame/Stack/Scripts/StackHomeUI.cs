using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackHomeUI : StackBaseUI
{
    Button startButton;
    Button exitButton;
    protected override StackUIState GetUIState()
    {
        return StackUIState.Home;
    }

    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    //  Start ��ư�� ������ ���ӽ���
    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }


    //  Exit ��ư�� ������ �ٽ� MainScene���� ���ư�
    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
