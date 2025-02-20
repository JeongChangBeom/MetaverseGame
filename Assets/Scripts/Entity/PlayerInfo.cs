using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }

    [Range(1f, 20f)][SerializeField] private float playerSpeed = 10f;
    public float PlayerSpeed
    {
        get => playerSpeed;
        set => playerSpeed = Mathf.Clamp(value, 0, 20);
    }

    private Vector3 playerPosition = new Vector3(0, 0, 0);
    public Vector3 PlayerPosition
    {
        get => playerPosition;
        set => playerPosition = value;
    }

    private Color playerColor = new Color(1f, 1f, 1f);
    public Color PlayerColor
    {
        get => playerColor;
        set => playerColor = value;
    }

    private Item playerItem = Item.Null;
    public Item PlayerItem
    {
        get => playerItem;
        set => playerItem = value;
    }
}
