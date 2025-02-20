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

    //  Start 버튼을 누르면 게임시작
    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }


    //  Exit 버튼을 누르면 다시 MainScene으로 돌아감
    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
