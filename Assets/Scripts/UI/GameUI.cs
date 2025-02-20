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
    
    //  Custom 버튼을 클릭하면 CustomUI가 활성화 됨
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
