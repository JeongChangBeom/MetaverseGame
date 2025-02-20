using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI chatText;
    [SerializeField] private Image portrait;
    [SerializeField] private Sprite[] portraitArr;
    private string[] talkData;
    private int currentIndex;

    SpriteRenderer playerSR;


    private void Start()
    {
        playerSR = GameObject.Find("Player/MainSprite").GetComponent<SpriteRenderer>();
        portraitArr = new Sprite[10];
        portraitArr[1] = playerSR.sprite;
        currentIndex = 0;
    }
    private void OnEnable()
    {
        UpdateTalk();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextTalk();
        }
    }

    public void NextTalk()
    {
        currentIndex++;
        if (currentIndex < talkData.Length)
        {
            UpdateTalk();
        }
        else
        {
            uiManager.ChangeState(UIState.Game);
        }
    }
    public void GetData(string[] arr, Sprite sp)
    {
        talkData = arr;
        portraitArr[0] = sp;
    }

    void UpdateTalk()
    {
        if (talkData[currentIndex].Split(':')[1] == "0")
        {
            portrait.sprite = portraitArr[0];
            Debug.Log("¹ú·¹ ÃÊ»óÈ­");
        }
        else
        {
            portrait.sprite = portraitArr[1];

        }

        chatText.text = talkData[currentIndex].Split(':')[0];
    }

    protected override UIState GetUIState()
    {
        return UIState.Chat;
    }
}
