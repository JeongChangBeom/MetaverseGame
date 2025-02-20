using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBoxUI : BaseUI
{
    [SerializeField] private Button stackButton;
    [SerializeField] private Button agentRunButton;

    PlayerController playerController;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        stackButton.onClick.AddListener(OnClickStackButton);
        agentRunButton.onClick.AddListener(OnClickAgentRunButton);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //  Stack 버튼을 누르면 스택 미니게임 진행
    public void OnClickStackButton()
    {
        //  씬이 바뀔 때 현재 플레이어 위치를 저장
        PlayerInfo.instance.PlayerPosition = playerController.transform.position;
        SceneManager.LoadScene("StackScene");
    }
    //  Agent Run 버튼을 누르면 Agent Run 미니게임 진행
    public void OnClickAgentRunButton()
    {
        //  씬이 바뀔 때 현재 플레이어 위치를 저장
        PlayerInfo.instance.PlayerPosition = playerController.transform.position;
        SceneManager.LoadScene("AgentRunScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameBox;
    }

}