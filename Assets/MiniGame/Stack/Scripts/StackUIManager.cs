using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StackUIState
{
    Game,
    Home,
    Score,
}

public class StackUIManager : MonoBehaviour
{
    static StackUIManager instance;

    public static StackUIManager Instance
    {
        get { return instance; }
    }

    StackUIState currentState = StackUIState.Home;

    StackHomeUI homeUI = null;
    StackGameUI gameUI = null;
    StackScoreUI scoreUI = null;

    StackTheStack theStack = null;

    private void Awake()
    {
        instance = this;

        theStack = FindObjectOfType<StackTheStack>();

        homeUI = GetComponentInChildren<StackHomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<StackGameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<StackScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(StackUIState.Home);
    }

    public void ChangeState(StackUIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(StackUIState.Game);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(StackUIState.Score);
    }
}
