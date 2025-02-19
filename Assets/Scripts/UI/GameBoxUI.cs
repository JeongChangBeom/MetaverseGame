using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBoxUI : BaseUI
{
    [SerializeField] private Button stackButton;

    PlayerController playerController;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        stackButton.onClick.AddListener(OnClickStackButton);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OnClickStackButton()    {
        SceneManager.LoadScene("StackScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameBox;
    }

}