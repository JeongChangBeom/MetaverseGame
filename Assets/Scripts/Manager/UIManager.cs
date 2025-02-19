using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    Game,
    GameBox,
}

public class UIManager : MonoBehaviour
{
    GameBoxUI gameBoxUI;

    private UIState currentState;

    private void Awake()
    {
        gameBoxUI = GetComponentInChildren<GameBoxUI>(true);
        gameBoxUI.Init(this);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        gameBoxUI.SetActive(currentState);
    }
}