using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private Button comstomButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        comstomButton.onClick.AddListener(OnClickComtomButton);
    }
    
    public void OnClickComtomButton()
    {
        uiManager.ChangeState(UIState.Comstom);
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
