using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI stackBestScoreText;
    [SerializeField] private TextMeshProUGUI agentRunBestScoreText;

    //  UI�� Ȱ��ȭ �� �� ȣ��
    private void OnEnable()
    {
        UpdateLeaderboard();
    }

    //  PlayerPrefs�� ������ Stack�� AgentRun�� �ְ����� ������
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
