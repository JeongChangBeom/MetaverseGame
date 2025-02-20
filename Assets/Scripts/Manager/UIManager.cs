using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    Game,
    GameBox,
    Leaderboard,
    Comstom,
}

public class UIManager : MonoBehaviour
{
    GameBoxUI gameBoxUI;
    LeaderboardUI leaderboardUI;
    GameUI gameUI;
    CostomUI costomUI;

    private UIState currentState;

    private void Awake()
    {
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);

        gameBoxUI = GetComponentInChildren<GameBoxUI>(true);
        gameBoxUI.Init(this);

        leaderboardUI = GetComponentInChildren<LeaderboardUI>(true);
        leaderboardUI.Init(this);

        costomUI = GetComponentInChildren<CostomUI>(true);
        costomUI.Init(this);


        ChangeState(UIState.Game);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        gameUI.SetActive(currentState);
        gameBoxUI.SetActive(currentState);
        leaderboardUI.SetActive(currentState);
        costomUI.SetActive(currentState);

        Debug.Log(currentState);
    }
}