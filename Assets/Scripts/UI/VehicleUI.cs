using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Vehicle
{
    Null,
    RedCar,
    BlueCar,
}

public class VehicleUI : BaseUI
{
    [SerializeField] private Button walkButton;
    [SerializeField] private Button redButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button saveButton;

    [SerializeField] private Image vehicleImage;

    private Vehicle currentVehicle = Vehicle.Null;

    private PlayerInfo playerInfo;
    private PlayerController playerController;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        walkButton.onClick.AddListener(OnClickWalkButton);
        redButton.onClick.AddListener(OnClickRedCarButton);
        blueButton.onClick.AddListener(OnClickBlueButton);
        saveButton.onClick.AddListener(OnClickSaveButton);

        playerInfo = PlayerInfo.instance;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnDisable()
    {
        playerInfo.PlayerVehicle = currentVehicle;
        playerController.RideVehicle(currentVehicle);
    }

    public void OnClickWalkButton()
    {
        vehicleImage.sprite = Resources.Load<Sprite>("Walk");
        currentVehicle = Vehicle.Null;
    }
    public void OnClickRedCarButton()
    {
        vehicleImage.sprite = Resources.Load<Sprite>("RedCar");
        currentVehicle = Vehicle.RedCar;
    }
    public void OnClickBlueButton()
    {
        vehicleImage.sprite = Resources.Load<Sprite>("BlueCar");
        currentVehicle = Vehicle.BlueCar;
    }
    public void OnClickSaveButton()
    {
        uiManager.ChangeState(UIState.Game);
    }

    protected override UIState GetUIState()
    {
        return UIState.Vehicle;
    }
}
