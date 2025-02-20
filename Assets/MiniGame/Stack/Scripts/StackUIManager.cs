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

    //  매개변수로 입력받은 값의 UI로 전환
    public void ChangeState(StackUIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    //  게임 시작
    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(StackUIState.Game);
    }

    //  MainScene으로 복귀
    public void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    //  GameUI의 현재 점수, 현재 콤보, 최고 콤보를 갱신해줌
    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.combo, theStack.MaxCombo);
    }

    //  ScoreUI의 현재 점수, 현재 최고 콤보, 최고 점수, 최고 콤보를 갱신해줌)
    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(StackUIState.Score);
    }
}
