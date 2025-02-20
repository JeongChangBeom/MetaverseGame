using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//  UI ���
public enum UIState
{
    Game,
    GameBox,
    Leaderboard,
    Custom,
    Chat,
    Vehicle,
}

public class UIManager : MonoBehaviour
{
    GameBoxUI gameBoxUI;
    LeaderboardUI leaderboardUI;
    GameUI gameUI;
    CustomUI customUI;
    ChatUI chatUI;
    VehicleUI vehicleUI;

    private UIState currentState;

    private void Awake()
    {
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);

        gameBoxUI = GetComponentInChildren<GameBoxUI>(true);
        gameBoxUI.Init(this);

        leaderboardUI = GetComponentInChildren<LeaderboardUI>(true);
        leaderboardUI.Init(this);

        customUI = GetComponentInChildren<CustomUI>(true);
        customUI.Init(this);

        chatUI = GetComponentInChildren<ChatUI>(true);
        chatUI.Init(this);

        vehicleUI = GetComponentInChildren<VehicleUI>(true);
        vehicleUI.Init(this);

        //  ó���� GameUI
        ChangeState(UIState.Game);
    }

    //  �Ű������� �Է¹��� ���� UI�� Ȱ��ȭ ��Ŵ
    public void ChangeState(UIState state)
    {
        currentState = state;

        gameUI.SetActive(currentState);
        gameBoxUI.SetActive(currentState);
        leaderboardUI.SetActive(currentState);
        customUI.SetActive(currentState);
        chatUI.SetActive(currentState);
        vehicleUI.SetActive(currentState);
    }
}