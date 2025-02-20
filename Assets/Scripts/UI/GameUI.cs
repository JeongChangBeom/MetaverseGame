using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private Button customButton;
    [SerializeField] private Button vehicleButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        customButton.onClick.AddListener(OnClickCustomButton);
        vehicleButton.onClick.AddListener(OnClickVehicleButton);
    }
    
    //  Custom ��ư�� Ŭ���ϸ� CustomUI�� Ȱ��ȭ ��
    public void OnClickCustomButton()
    {
        uiManager.ChangeState(UIState.Custom);
    }

    public void OnClickVehicleButton()
    {
        uiManager.ChangeState(UIState.Vehicle);
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
