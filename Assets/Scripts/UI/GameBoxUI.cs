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

    public void OnClickStackButton()
    {
        PlayerInfo.instance.PlayerPosition = playerController.transform.position;
        SceneManager.LoadScene("StackScene");
    }
    public void OnClickAgentRunButton()
    {
        PlayerInfo.instance.PlayerPosition = playerController.transform.position;
        SceneManager.LoadScene("AgentRunScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameBox;
    }

}