using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] private float speed = 10f;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
