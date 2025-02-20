using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI chatText;
    [SerializeField] private Image portrait;
    private string[] talkData;
    private int currentIndex;

    private void OnEnable()
    {
        currentIndex = 0;
        UpdateDialogue();
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
            UpdateDialogue();
        }
        else
        {
            uiManager.ChangeState(UIState.Game);
        }
    }
    public void GetData(string[] arr, Sprite sp)
    {
        talkData = arr;
        portrait.sprite = sp;
    }

    void UpdateDialogue()
    {
        chatText.text = talkData[currentIndex];
    }

    protected override UIState GetUIState()
    {
        return UIState.Chat;
    }
}
