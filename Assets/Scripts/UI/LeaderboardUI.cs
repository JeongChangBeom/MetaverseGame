using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI stackBestScoreText;
    [SerializeField] private TextMeshProUGUI agentRunBestScoreText;

    //  UI가 활성화 될 때 호출
    private void OnEnable()
    {
        UpdateLeaderboard();
    }

    //  PlayerPrefs에 저장한 Stack과 AgentRun의 최고기록을 보여줌
    private void UpdateLeaderboard()
    {
        stackBestScoreText.text = PlayerPrefs.GetInt("StackBestScoreKey", 0).ToString();
        agentRunBestScoreText.text = PlayerPrefs.GetInt("AgentRunBestScoreKey", 0).ToString();
    } 

    protected override UIState GetUIState()
    {
        return UIState.Leaderboard;
    }
}
