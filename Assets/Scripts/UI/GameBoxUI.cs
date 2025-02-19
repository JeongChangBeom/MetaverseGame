using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoxUI : BaseUI
{
    [SerializeField] private Button stackButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        stackButton.onClick.AddListener(OnClickStackButton);
    }

    public void OnClickStackButton()
    {
        Debug.Log("스택 실행");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameBox;
    }

}
