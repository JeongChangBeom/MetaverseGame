using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public enum Item
{
    Null,
    Sword,
    Bow,
    Hammer,
}

public class CustomUI : BaseUI
{
    [SerializeField] private Button swordButton;
    [SerializeField] private Button bowButton;
    [SerializeField] private Button hammerButton;
    [SerializeField] private Button saveButton;

    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;


    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject item;

    [SerializeField] private Image playerImage;

    private Item currentItem = Item.Null;
    private Color currentColor = new Color(1f, 1f, 1f);

    private PlayerController playerController;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        swordButton.onClick.AddListener(OnClickSwordButton);
        bowButton.onClick.AddListener(OnClickBowButton);
        hammerButton.onClick.AddListener(OnClickHammerButton);
        saveButton.onClick.AddListener(OnClickSaveButton);
    }

    private void Update()
    {
        UpdateColor();
    }

    //  UI가 비활성화 될 때 커스텀창에서 바꾼 내용을 플레이어에게 적용
    private void OnDisable()
    {
        playerController.EquipItem(currentItem);
        playerController.ApplyColor(currentColor);
    }

    //  커스텀창에서 컬러 변경
    private void UpdateColor()
    {
        currentColor.r = redSlider.value / 255.0f;
        currentColor.g = greenSlider.value / 255.0f;
        currentColor.b = blueSlider.value / 255.0f;

        playerImage.color = currentColor;
    }

    //  검 그림의 버튼을 클릭하면 검 장착
    public void OnClickSwordButton()
    {
        item.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>("Sword");
        currentItem = Item.Sword;

        PlayerInfo.instance.PlayerItem = Item.Sword;
    }

    //  활 그림의 버튼을 클릭하면 활 장착
    public void OnClickBowButton()
    {
        item.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>("Bow");
        currentItem = Item.Bow;

        PlayerInfo.instance.PlayerItem = Item.Bow;
    }

    //  망치 그림의 버튼을 클릭하면 망치 장착
    public void OnClickHammerButton()
    {
        item.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>("Hammer");
        currentItem = Item.Hammer;

        PlayerInfo.instance.PlayerItem = Item.Hammer;
    }

    //  Save 버튼을 누르면 CustomUI가 비활성화되고 GameUI가 활성화 됨
    public void OnClickSaveButton()
    {
        uiManager.ChangeState(UIState.Game);
    }

    protected override UIState GetUIState()
    {
        return UIState.Custom;
    }
}
