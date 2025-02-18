using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Vector2 offset;

    private void Start()
    {
        if(target == null)
        {
            return;
        }

        offset = transform.position - target.position;
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.x = target.position.x + offset.x;
        pos.y = target.position.y + offset.y;
        transform.position = pos;
    }
}
