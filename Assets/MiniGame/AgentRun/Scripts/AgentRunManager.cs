using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AgentRunManager : MonoBehaviour
{
    static AgentRunManager agentRunManager;
    public static AgentRunManager Instance { get { return agentRunManager; } }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestRecordText;
    [SerializeField] private TextMeshProUGUI currentRecordText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    AgentRunPlayerController player;

    public GameObject gameOverUI;

    private float currentScore = 0f;

    int agnetRunBestScore = 0;
    public int AgentRunBestScore { get => agnetRunBestScore; }

    private void Awake()
    {
        agentRunManager = this;
        gameOverUI.SetActive(false);
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<AgentRunPlayerController>();
        gameOverUI.SetActive(false);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);

        agnetRunBestScore = PlayerPrefs.GetInt("AgentRunBestScoreKey", 0);
    }

    private void Update()
    {
        //  플레이어가 죽지 않았으면 계속해서 현재 점수 갱신
        if (!player.IsDead)
        {
            currentScore += Time.deltaTime;
        }

        UpdateScore(currentScore);
    }


    //  플레이어가 죽으면 현재점수와 최고점수를 보여줌
    public void GameOver()
    {

        if (agnetRunBestScore < currentScore)
        {
            agnetRunBestScore = (int)currentScore;

            PlayerPrefs.SetInt("AgentRunBestScoreKey", agnetRunBestScore);

        }

        Invoke("GameOverInvoke", 1.0f);
    }

    private void GameOverInvoke()
    {
        gameOverUI.SetActive(true);
        bestRecordText.text = agnetRunBestScore.ToString();
        currentRecordText.text = ((int)currentScore).ToString();
    }

    //  게임 점수를 UI에 보여줌
    private void UpdateScore(float score)
    {
        scoreText.text = ((int)score).ToString();
    }

    //  Restart 버튼을 누르면 게임 재시작
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    //  Exit 버튼을 누르면 다시 MainScene으로 돌아감
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
