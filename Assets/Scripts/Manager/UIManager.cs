using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    Game,
    GameBox,
    Leaderboard,
    Custom,
}

public class UIManager : MonoBehaviour
{
    GameBoxUI gameBoxUI;
    LeaderboardUI leaderboardUI;
    GameUI gameUI;
    CustomUI customUI;

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

        ChangeState(UIState.Game);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        gameUI.SetActive(currentState);
        gameBoxUI.SetActive(currentState);
        leaderboardUI.SetActive(currentState);
        customUI.SetActive(currentState);

        Debug.Log(currentState);
    }
}